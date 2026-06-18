using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Game15Library;

namespace Game15App
{
    /// <summary>
    /// Главная форма игры «15».
    /// Отвечает только за отображение и перенаправление событий пользователя в модель.
    /// Никакой игровой логики здесь нет — всё в GameModel.
    /// </summary>
    public class MainForm : Form
    {
        // ──────── Модель ────────
        private readonly GameModel _model;

        // ──────── Элементы интерфейса ────────
        private Panel _boardPanel;
        private readonly Button[] _tileBtns = new Button[16];
        private Button _newGameBtn;
        private Button _exitBtn;
        private Label _timerLabel;
        private readonly System.Windows.Forms.Timer _uiTimer;

        // ──────── Константы размеров ────────
        private const int TileSize    = 78;
        private const int TileGap     = 6;
        private const int BoardPad    = 10;
        private const int BoardSide   = TileSize * 4 + TileGap * 3 + BoardPad * 2; // 368
        private const int FormPad     = 12;

        // ──────── Цвета ────────
        private static readonly Color ColBackground  = Color.FromArgb(240, 240, 240);
        private static readonly Color ColBoardBg     = Color.FromArgb(180, 180, 180);
        private static readonly Color ColTileNormal  = Color.FromArgb(220, 220, 220);
        private static readonly Color ColTileHover   = Color.FromArgb(200, 210, 230);
        private static readonly Color ColEmpty       = Color.FromArgb(150, 150, 150);
        private static readonly Color ColText        = Color.FromArgb(50, 50, 50);
        private static readonly Color ColBtnAction   = Color.FromArgb(210, 225, 210);

        // ──────────────────────────────────────────────────────────────

        public MainForm()
        {
            _model = new GameModel();
            _model.BoardChanged += OnBoardChanged;
            _model.GameWon      += OnGameWon;

            _uiTimer = new System.Windows.Forms.Timer { Interval = 500 };
            _uiTimer.Tick += (_, _) => UpdateTimerLabel();

            InitComponents();
            RenderBoard(_model.GetBoard(), _model.EmptyIndex);
        }

        // ══════════════════════ Инициализация UI ══════════════════════

        private void InitComponents()
        {
            // ── Форма ──
            Text = "Игра «15»";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox     = false;
            BackColor       = ColBackground;
            StartPosition   = FormStartPosition.CenterScreen;

            int formW = BoardSide + FormPad * 2;
            int formH = BoardSide + 130;
            ClientSize = new Size(formW, formH);

            // ── Панель игрового поля ──
            _boardPanel = new Panel
            {
                Location  = new Point(FormPad, FormPad),
                Size      = new Size(BoardSide, BoardSide),
                BackColor = ColBoardBg
            };
            Controls.Add(_boardPanel);

            // ── 16 кнопок-фишек ──
            for (int i = 0; i < 16; i++)
            {
                int row = i / 4, col = i % 4;
                var btn = new Button
                {
                    Size      = new Size(TileSize, TileSize),
                    Location  = new Point(
                        BoardPad + col * (TileSize + TileGap),
                        BoardPad + row * (TileSize + TileGap)),
                    FlatStyle = FlatStyle.Flat,
                    Font      = new Font("Segoe UI", 20, FontStyle.Bold),
                    ForeColor = ColText,
                    BackColor = ColTileNormal,
                    Tag       = i,
                    Cursor    = Cursors.Hand
                };
                btn.FlatAppearance.BorderColor = Color.FromArgb(180, 180, 180);
                btn.FlatAppearance.BorderSize  = 1;

                int idx = i;
                btn.MouseUp    += TileBtn_MouseUp;
                btn.MouseEnter += (_, _) => { if (btn.Enabled && _model.CanMove(idx)) btn.BackColor = ColTileHover; };
                btn.MouseLeave += (_, _) => { if (btn.Enabled) btn.BackColor = ColTileNormal; };

                _tileBtns[i] = btn;
                _boardPanel.Controls.Add(btn);
            }

            // ── Метка таймера ──
            _timerLabel = new Label
            {
                Location  = new Point(FormPad, BoardSide + FormPad + 8),
                Size      = new Size(BoardSide, 24),
                TextAlign = ContentAlignment.MiddleCenter,
                Font      = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(80, 80, 80),
                Text      = "Нажмите «Новая игра»"
            };
            Controls.Add(_timerLabel);

            // ── Кнопка «Новая игра» ──
            _newGameBtn = MakeButton("Новая игра",
                new Point(FormPad, BoardSide + FormPad + 42),
                new Size(BoardSide / 2 - 4, 40));
            _newGameBtn.Click += (_, _) => StartNewGame();
            Controls.Add(_newGameBtn);

            // ── Кнопка «Выход» ──
            _exitBtn = MakeButton("Выход",
                new Point(FormPad + BoardSide / 2 + 4, BoardSide + FormPad + 42),
                new Size(BoardSide / 2 - 4, 40));
            _exitBtn.Click += (_, _) => Application.Exit();
            Controls.Add(_exitBtn);
        }

        private static Button MakeButton(string text, Point loc, Size size)
        {
            var btn = new Button
            {
                Text      = text,
                Location  = loc,
                Size      = size,
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI", 11),
                BackColor = ColBtnAction,
                ForeColor = ColText,
                Cursor    = Cursors.Hand
            };
            btn.FlatAppearance.BorderColor = Color.FromArgb(160, 180, 160);
            return btn;
        }

        // ══════════════════════ Игровые действия ══════════════════════

        private void StartNewGame()
        {
            _model.NewGame();
            _uiTimer.Start();
            UpdateTimerLabel();
        }

        // ══════════════════════ Обработчики событий модели ══════════════════════

        private void OnBoardChanged(object? sender, BoardChangedEventArgs e)
        {
            // Если вызвано не из UI-потока — маршалируем
            if (InvokeRequired) { Invoke(() => RenderBoard(e.Board, e.EmptyIndex)); return; }
            RenderBoard(e.Board, e.EmptyIndex);
        }

        private void OnGameWon(object? sender, GameWonEventArgs e)
        {
            if (InvokeRequired) { Invoke(() => ShowWinMessage(e.Elapsed)); return; }
            ShowWinMessage(e.Elapsed);
        }

        // ══════════════════════ Рендер ══════════════════════

        private void RenderBoard(int[] board, int emptyIndex)
        {
            for (int i = 0; i < 16; i++)
            {
                var btn = _tileBtns[i];
                int val = board[i];

                if (val == 0)
                {
                    // Пустая клетка — невидимая «фишка» (Button без текста)
                    btn.Text      = "";
                    btn.BackColor = ColEmpty;
                    btn.Enabled   = false;
                    btn.FlatAppearance.BorderSize = 0;
                }
                else
                {
                    btn.Text      = val.ToString();
                    btn.BackColor = ColTileNormal;
                    btn.Enabled   = _model.GameInProgress;
                    btn.FlatAppearance.BorderSize = 1;
                }
            }
        }

        private void TileBtn_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (sender is Button btn && btn.Tag is int idx)
                _model.TryMove(idx);
        }

        private void UpdateTimerLabel()
        {
            if (!_model.GameInProgress) return;
            var t = _model.GetElapsedTime();
            _timerLabel.Text = $"Время: {(int)t.TotalMinutes:D2}:{t.Seconds:D2}";
        }

        private void ShowWinMessage(TimeSpan elapsed)
        {
            _uiTimer.Stop();
            _timerLabel.Text = $"Решено за {(int)elapsed.TotalMinutes:D2}:{elapsed.Seconds:D2}";

            // Отключаем все фишки
            foreach (var btn in _tileBtns) btn.Enabled = false;

            MessageBox.Show(
                $"Поздравляем!\n\nВы решили головоломку «15»!\n\nВремя: {(int)elapsed.TotalMinutes:D2}:{elapsed.Seconds:D2}",
                "Победа!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Освобождаем ресурсы таймера при закрытии
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _uiTimer.Dispose();
            base.OnFormClosed(e);
        }
    }
}
