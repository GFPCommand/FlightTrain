using Timer = System.Windows.Forms.Timer;

namespace FlightTrain
{
    public partial class SpeedTrainingForm : Form
    {
        private readonly int _maxX, _maxY;
        private readonly int _enemyCount = 3;

        private const int _elementSize = 50;

        private const int _transitionCoefficient = 5;

        private int _x, _y;

        private bool _isCollision;
        private bool _isStart;

		private List<Enemy> _enemies = new();

		private DateTime _startTime, _endTime, _resultTime;

		readonly Timer timer = new();        

        private delegate void SelectWayObject(short num);
        private delegate void ShowHideMenuObj(object? sender, EventArgs e);

        private event SelectWayObject SelectWayObjectEvent;
        private event ShowHideMenuObj MenuEvent;

        public SpeedTrainingForm()
        {
            InitializeComponent();

            _x = _y = 0;

            _maxX = Size.Width;
            _maxY = Size.Height;

            _isCollision = false;
            _isStart = false;
            
            for (int i = 0; i < _enemyCount; i++)
			{
				_enemies.Add(new Enemy());                
			}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var enemy in _enemies)
            {
				Controls.Add(enemy);
			}

            player.Visible = true;

            SpawnEnemies();

			timer.Tick += Update;
            timer.Interval = 10;

            SelectWayObjectEvent += SelectWay;
            MenuEvent += ShowHideMenu;
        }

        private void player_MouseDown(object? sender, MouseEventArgs e)
        {
            _x = e.X;
            _y = e.Y;
        }

        private void player_MouseMove(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _isStart)
            {
                Point pos = new(Cursor.Position.X -_x, Cursor.Position.Y - _y);
                player.Location = PointToClient(pos);
            }
        }

		private void exit_Click(object sender, EventArgs e) => Application.Exit();

		private void Update(object? sender, EventArgs e)
        {
            for (short i = 0; i < _enemyCount; i++)
            {
                _enemies[i].Location = new(_enemies[i].Location.X + _enemies[i].HorizontalTransition, _enemies[i].Location.Y + _enemies[i].VerticalTransition);

                if (_enemies[i].Location.X > _maxX - _elementSize || _enemies[i].Location.Y > _maxY - _elementSize || _enemies[i].Location.X < 0 || _enemies[i].Location.Y < 0)
                {
                    if (_enemies[i].Location.X > _maxX - _elementSize) _enemies[i].Location = new(_maxX - _elementSize, _enemies[i].Location.Y);
                    if (_enemies[i].Location.Y > _maxY - _elementSize) _enemies[i].Location = new(_enemies[i].Location.Y, _maxY - _elementSize);

                    if (_enemies[i].Location.X < 0) _enemies[i].Location = new(0, _enemies[i].Location.Y);
                    if (_enemies[i].Location.Y < 0) _enemies[i].Location = new(_enemies[i].Location.X, 0);

                    SelectWayObjectEvent?.Invoke(i);
                }
            }

            if (player.Location.X > _maxX)
            {
                player.Location = new(_maxX, player.Location.Y);
            } else if (player.Location.Y > _maxY)
            {
                player.Location = new(player.Location.X, _maxY);
            }

            if (CheckCollisionObjects())
            {
                MenuEvent?.Invoke(sender, e);
            }
        }

        private bool CheckCollisionObjects()
        {
            foreach (var enemy in _enemies)
            {
                if (player.Bounds.IntersectsWith(enemy.Bounds)) _isCollision = true;
            }

            return _isCollision;
        }

        private void ShowHideMenu(object? sender, EventArgs e)
        {
            if (!_isStart)
            {
                SpawnEnemies();

                _startTime = DateTime.Now;

                _isStart = true;
                _isCollision = false;

                panel.Visible = false;

                timer.Start();
            }

            if (_isCollision)
            {
                _isStart = false;
                panel.Visible = true;

                _endTime = DateTime.Now;
                _resultTime = new DateTime(_endTime.Year, _endTime.Month, _endTime.Day, _endTime.Hour, _endTime.Minute - _startTime.Minute, _endTime.Second - _startTime.Second, Math.Abs(_endTime.Millisecond - _startTime.Millisecond));

                StartLoseLabel.Text = "Вы проиграли";
                time.Text = $"{_resultTime.Minute}м:{_resultTime.Second}с:{_resultTime.Millisecond}мс";
                timer.Stop();
            }
        }

        private void SpawnEnemies()
        {
            Random rand = new();

            for (short i = 0; i < _enemyCount; i++)
            {
                int posX = rand.Next(0, _maxY - _elementSize);
                int posY = rand.Next(0, _maxY - _elementSize);

                _enemies[i].Location = new Point(posX, posY);
                _enemies[i].Visible = true;
                SelectWay(i);
            }
        }

		private void SelectWay(short enemyNumber)
		{
			int choose;

			Random rand = new();

            choose = rand.Next(0, 8);

            SelectWayOptions(choose, enemyNumber);
		}

		private void SelectWayOptions(int rndVal, short num)
        {
            switch (rndVal)
            {
                case 0: //up
                    _enemies[num].VerticalTransition = _transitionCoefficient;
                    _enemies[num].HorizontalTransition = 0;
                    break;
                case 1://down
					_enemies[num].VerticalTransition = - _transitionCoefficient;
					_enemies[num].HorizontalTransition = 0;
					break;
                case 2://right
                    _enemies[num].VerticalTransition = 0;
                    _enemies[num].HorizontalTransition = _transitionCoefficient;
                    break;
                case 3://left
					_enemies[num].VerticalTransition = 0;
					_enemies[num].HorizontalTransition = - _transitionCoefficient;
                    break;
                case 4:
                    _enemies[num].VerticalTransition = - _transitionCoefficient;
                    _enemies[num].HorizontalTransition = _transitionCoefficient;
                    break;
                case 5:
					_enemies[num].VerticalTransition = _transitionCoefficient;
                    _enemies[num].HorizontalTransition = _transitionCoefficient;
                    break;
                case 6:
					_enemies[num].VerticalTransition = _transitionCoefficient;
					_enemies[num].HorizontalTransition = - _transitionCoefficient;
                    break;
                case 7:
					_enemies[num].VerticalTransition = - _transitionCoefficient;
					_enemies[num].HorizontalTransition = - _transitionCoefficient;
					break;
                default:
                    break;
            }
        }
    }
}
