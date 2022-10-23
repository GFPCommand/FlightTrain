using Timer = System.Windows.Forms.Timer;

namespace FlightTrain
{
    public partial class Form1 : Form
    {
        private readonly int _maxX, _maxY;
        private const int _elementSize = 50;
        private int _verticalTransition1,_horizontalTransition1;
        private int _verticalTransition2, _horizontalTransition2;
        private int _verticalTransition3, _horizontalTransition3;

        private const int _transitionCoefficient = 5;

        private int _x, _y;

        private bool _isCollision;
        private bool _isStart;

        private delegate void SelectWayObject(short num);
        private delegate void ShowHideMenuObj(object? sender, EventArgs e);

        private event SelectWayObject SelectWayObjectEvent;
        private event ShowHideMenuObj MenuEvent;

        private DateTime _startTime, _endTime, _resultTime;

        Timer timer = new();

        public Form1()
        {
            InitializeComponent();

            _x = _y = 0;

            _maxX = Size.Width;
            _maxY = Size.Height;

            _isCollision = false;
            _isStart = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
                Point pos = new Point(Cursor.Position.X -_x, Cursor.Position.Y - _y);
                player.Location = PointToClient(pos);
            }
        }

        private void Update(object? sender, EventArgs e)
        {
            enemy1.Location = new (enemy1.Location.X + _horizontalTransition1, enemy1.Location.Y + _verticalTransition1);
            enemy2.Location = new (enemy2.Location.X - _horizontalTransition2, enemy2.Location.Y - _verticalTransition2);
            enemy3.Location = new (enemy3.Location.X + _horizontalTransition3, enemy3.Location.Y - _verticalTransition3);

            if (enemy1.Location.X > _maxX - _elementSize || enemy1.Location.Y > _maxY - _elementSize || enemy1.Location.X < 0 || enemy1.Location.Y < 0)
            {
                if (enemy1.Location.X > _maxX - _elementSize) enemy1.Location = new(_maxX - _elementSize, enemy1.Location.Y);
                if (enemy1.Location.Y > _maxY - _elementSize) enemy1.Location = new(enemy1.Location.Y, _maxY - _elementSize);

                if (enemy1.Location.X < 0) enemy1.Location = new(0, enemy1.Location.Y);
                if (enemy1.Location.Y < 0) enemy1.Location = new(enemy1.Location.X, 0);
                
                SelectWayObjectEvent?.Invoke(1);
            }
            
            if (enemy2.Location.X > _maxX - _elementSize || enemy2.Location.Y > _maxY - _elementSize || enemy2.Location.X < 0 || enemy2.Location.Y < 0)
            {
                if (enemy2.Location.X > _maxX - _elementSize) enemy2.Location = new(_maxX - _elementSize, enemy2.Location.Y);
                if (enemy2.Location.Y > _maxY - _elementSize) enemy2.Location = new(enemy2.Location.Y, _maxY - _elementSize);

                if (enemy2.Location.X < 0) enemy2.Location = new(0, enemy2.Location.Y);
                if (enemy2.Location.Y < 0) enemy2.Location = new(enemy2.Location.X, 0);

                SelectWayObjectEvent?.Invoke(2);
            }
            
            if (enemy3.Location.X > _maxX - _elementSize  || enemy3.Location.Y > _maxY - _elementSize  || enemy3.Location.X < 0 || enemy3.Location.Y < 0)
            {
                if (enemy3.Location.X > _maxX - _elementSize) enemy3.Location = new(_maxX - _elementSize, enemy3.Location.Y);
                if (enemy3.Location.Y > _maxY - _elementSize) enemy3.Location = new(enemy1.Location.Y, _maxY - _elementSize);

                if (enemy3.Location.X < 0) enemy3.Location = new(0, enemy3.Location.Y);
                if (enemy3.Location.Y < 0) enemy3.Location = new(enemy3.Location.X, 0);

                SelectWayObjectEvent?.Invoke(3);
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

        private void SelectWay(short enemyNumber)
        {
            int choose;

            Random rand = new Random();

            switch (enemyNumber)
            {
                case 1:
                    choose = rand.Next(0, 8);

                    SelectWayOptions(choose, enemyNumber);
                    break;
                case 2:
                    choose = rand.Next(0, 8);

                    SelectWayOptions(choose, enemyNumber);
                    break;
                case 3:
                    choose = rand.Next(0, 8);

                    SelectWayOptions(choose, enemyNumber);
                    break;
                default:
                    break;
            }
        }

        private void exit_Click(object sender, EventArgs e) => Application.Exit();

        private bool CheckCollisionObjects()
        {
            if (player.Bounds.IntersectsWith(enemy1.Bounds) || player.Bounds.IntersectsWith(enemy2.Bounds) || player.Bounds.IntersectsWith(enemy3.Bounds))
            {
                _isCollision = true;
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

                StartLoseLabel.Text = "You lose";
                time.Text = $"{_resultTime.Minute}m:{_resultTime.Second}s:{_resultTime.Millisecond}ms";
                timer.Stop();
            }
        }

        private void SpawnEnemies()
        {
            Random rand = new Random();

            int posX = rand.Next(0, _maxY - _elementSize);
            int posY = rand.Next(0, _maxY - _elementSize);

            enemy1.Location = new Point(posX, posY);
            enemy1.Visible = true;

            posX = rand.Next(0, _maxY - _elementSize);
            posY = rand.Next(0, _maxY - _elementSize);

            enemy2.Location = new Point(posX, posY);
            enemy2.Visible = true;

            posX = rand.Next(0, _maxY - _elementSize);
            posY = rand.Next(0, _maxY - _elementSize);

            enemy3.Location = new Point(posX, posY);
            enemy3.Visible = true;

            posX = rand.Next(0, _maxY - _elementSize);
            posY = rand.Next(0, _maxY - _elementSize);

            player.Location = new Point(posX, posY);
            player.Visible = true;

            SelectWay(1);
            SelectWay(2);
            SelectWay(3);
        }

        private void SelectWayOptions(int rndVal, short num)
        {
            switch (rndVal)
            {
                case 0: //up
                    if (num == 1)
                    {
                        _verticalTransition1 = _transitionCoefficient;
                        _horizontalTransition1 = 0;
                    } else if (num == 2)
                    {
                        _verticalTransition2 = _transitionCoefficient;
                        _horizontalTransition2 = 0;
                    } else if (num == 3)
                    {
                        _verticalTransition3 = _transitionCoefficient;
                        _horizontalTransition3 = 0;
                    }
                    break;
                case 1://down
                    if (num == 1)
                    {
                        _verticalTransition1 = -_transitionCoefficient;
                        _horizontalTransition1 = 0;
                    }
                    else if (num == 2)
                    {
                        _verticalTransition2 = -_transitionCoefficient;
                        _horizontalTransition2 = 0;
                    }
                    else if (num == 3)
                    {
                        _verticalTransition3 = -_transitionCoefficient;
                        _horizontalTransition3 = 0;
                    }
                    break;
                case 2://right
                    if (num == 1)
                    {
                        _verticalTransition1 = 0;
                        _horizontalTransition1 = _transitionCoefficient;
                    }
                    else if (num == 2)
                    {
                        _verticalTransition2 = 0;
                        _horizontalTransition2 = _transitionCoefficient;
                    }
                    else if (num == 3)
                    {
                        _verticalTransition3 = 0;
                        _horizontalTransition3 = _transitionCoefficient;
                    }
                    break;
                case 3://left
                    if (num == 1)
                    {
                        _verticalTransition1 = 0;
                        _horizontalTransition1 = -_transitionCoefficient;
                    }
                    else if (num == 2)
                    {
                        _verticalTransition2 = 0;
                        _horizontalTransition2 = -_transitionCoefficient;
                    }
                    else if (num == 3)
                    {
                        _verticalTransition3 = 0;
                        _horizontalTransition3 = -_transitionCoefficient;
                    }
                    break;
                case 4:
                    if (num == 1)
                    {
                        _verticalTransition1 = -_transitionCoefficient;
                        _horizontalTransition1 = _transitionCoefficient;
                    } else if (num == 2)
                    {
                        _verticalTransition2 = -_transitionCoefficient;
                        _horizontalTransition2 = _transitionCoefficient;
                    } else if (num == 3)
                    {
                        _verticalTransition3 = -_transitionCoefficient;
                        _horizontalTransition3 = _transitionCoefficient;
                    }
                    break;
                case 5:
                    if (num == 1)
                    {
                        _verticalTransition1 = _transitionCoefficient;
                        _horizontalTransition1 = _transitionCoefficient;
                    } else if (num == 2)
                    {
                        _verticalTransition2 = _transitionCoefficient;
                        _horizontalTransition2 = _transitionCoefficient;
                    } else if (num == 3)
                    {
                        _verticalTransition3 = _transitionCoefficient;
                        _horizontalTransition3 = _transitionCoefficient;
                    }
                    break;
                case 6:
                    if (num == 1)
                    {
                        _verticalTransition1 = _transitionCoefficient;
                        _horizontalTransition1 = -_transitionCoefficient;
                    } else if (num == 2)
                    {
                        _verticalTransition2 = _transitionCoefficient;
                        _horizontalTransition2 = -_transitionCoefficient;
                    } else if (num == 3)
                    {
                        _verticalTransition3 = _transitionCoefficient;
                        _horizontalTransition3 = -_transitionCoefficient;
                    }
                    break;
                case 7:
                    if (num == 1)
                    {
                        _verticalTransition1 = -_transitionCoefficient;
                        _horizontalTransition1 = -_transitionCoefficient;
                    } else if (num == 2)
                    {
                        _verticalTransition2 = -_transitionCoefficient;
                        _horizontalTransition2 = -_transitionCoefficient;
                    } else if (num == 3)
                    {
                        _verticalTransition3 = -_transitionCoefficient;
                        _horizontalTransition3 = -_transitionCoefficient;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
