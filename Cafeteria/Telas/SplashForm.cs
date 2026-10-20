namespace Cafeteria.Telas;

public class SplashForm : Form
{
    ProgressBar barra = new ProgressBar();
    Label lblStatus = new Label();
    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

    public SplashForm()
    {
        FormBorderStyle = FormBorderStyle.None;
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(500, 280);
        BackColor = Estilo.Cafe;
        Font = new Font("Segoe UI", 10);

        var lblTitulo = new Label();
        lblTitulo.Text = "Cafeteria Dev";
        lblTitulo.Font = new Font("Segoe UI", 28, FontStyle.Bold);
        lblTitulo.ForeColor = Color.White;
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
        lblTitulo.Location = new Point(0, 70);
        lblTitulo.Size = new Size(500, 60);

        var lblSubtitulo = new Label();
        lblSubtitulo.Text = "Sistema de vendas";
        lblSubtitulo.Font = new Font("Segoe UI", 12);
        lblSubtitulo.ForeColor = Estilo.Creme;
        lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
        lblSubtitulo.Location = new Point(0, 130);
        lblSubtitulo.Size = new Size(500, 30);

        barra.Location = new Point(60, 205);
        barra.Size = new Size(380, 14);
        barra.Minimum = 0;
        barra.Maximum = 100;

        lblStatus.Text = "Carregando...";
        lblStatus.ForeColor = Estilo.Creme;
        lblStatus.Location = new Point(60, 225);
        lblStatus.Size = new Size(380, 25);

        Controls.Add(lblTitulo);
        Controls.Add(lblSubtitulo);
        Controls.Add(barra);
        Controls.Add(lblStatus);

        timer.Interval = 40;
        timer.Tick += Timer_Tick;
        Shown += (s, e) => timer.Start();
        FormClosed += (s, e) => timer.Dispose();
    }

    void Timer_Tick(object? sender, EventArgs e)
    {
        barra.Value = Math.Min(100, barra.Value + 2);

        if (barra.Value >= 100)
        {
            lblStatus.Text = "Pronto!";
            timer.Stop();
            Close();
        }
    }
}
