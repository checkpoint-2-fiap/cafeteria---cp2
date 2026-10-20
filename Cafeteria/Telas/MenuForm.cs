namespace Cafeteria.Telas;

public class MenuForm : Form
{
    public MenuForm()
    {
        Text = "Cafeteria Dev";
        ClientSize = new Size(420, 420);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        BackColor = Estilo.Fundo;
        Font = new Font("Segoe UI", 10);

        var lblTitulo = new Label();
        lblTitulo.Text = "Cafeteria Dev";
        lblTitulo.Font = new Font("Segoe UI", 24, FontStyle.Bold);
        lblTitulo.ForeColor = Estilo.Cafe;
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
        lblTitulo.Location = new Point(0, 30);
        lblTitulo.Size = new Size(420, 60);

        var lblSubtitulo = new Label();
        lblSubtitulo.Text = "Menu principal";
        lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
        lblSubtitulo.Location = new Point(0, 90);
        lblSubtitulo.Size = new Size(420, 30);

        var btnVenda = CriarBotao("Nova venda", 150);
        btnVenda.Click += BtnVenda_Click;

        var btnRelatorio = CriarBotao("Relatório de vendas", 230);
        btnRelatorio.Click += BtnRelatorio_Click;

        var btnSair = CriarBotao("Sair", 310);
        btnSair.Click += (s, e) => Close();

        Controls.Add(lblTitulo);
        Controls.Add(lblSubtitulo);
        Controls.Add(btnVenda);
        Controls.Add(btnRelatorio);
        Controls.Add(btnSair);
    }

    Button CriarBotao(string texto, int y)
    {
        var botao = new Button();
        botao.Text = texto;
        botao.Font = new Font("Segoe UI", 13);
        botao.Location = new Point(60, y);
        botao.Size = new Size(300, 60);
        Estilo.Botao(botao);
        return botao;
    }

    void BtnVenda_Click(object? sender, EventArgs e)
    {
        var tela = new VendaForm();
        tela.ShowDialog();
    }

    void BtnRelatorio_Click(object? sender, EventArgs e)
    {
        var tela = new RelatorioForm();
        tela.ShowDialog();
    }
}
