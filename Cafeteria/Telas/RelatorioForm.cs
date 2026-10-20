using Cafeteria.Dados;
using Cafeteria.Modelos;

namespace Cafeteria.Telas;

public class RelatorioForm : Form
{
    DateTimePicker dtpDe = new DateTimePicker();
    DateTimePicker dtpAte = new DateTimePicker();
    DataGridView gridVendas = new DataGridView();
    DataGridView gridItens = new DataGridView();
    Label lblResumo = new Label();

    public RelatorioForm()
    {
        Text = "Relatório de Vendas";
        ClientSize = new Size(960, 600);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        BackColor = Estilo.Fundo;
        Font = new Font("Segoe UI", 10);

        CriarTela();

        Load += (s, e) => Filtrar();
    }

    void CriarTela()
    {
        // Filtro por data
        var lblDe = new Label();
        lblDe.Text = "De:";
        lblDe.Location = new Point(20, 23);
        lblDe.Size = new Size(30, 25);

        dtpDe.Format = DateTimePickerFormat.Short;
        dtpDe.Location = new Point(55, 20);
        dtpDe.Size = new Size(120, 30);
        dtpDe.Value = DateTime.Today.AddDays(-30);

        var lblAte = new Label();
        lblAte.Text = "Até:";
        lblAte.Location = new Point(195, 23);
        lblAte.Size = new Size(35, 25);

        dtpAte.Format = DateTimePickerFormat.Short;
        dtpAte.Location = new Point(235, 20);
        dtpAte.Size = new Size(120, 30);
        dtpAte.Value = DateTime.Today;

        var btnFiltrar = new Button();
        btnFiltrar.Text = "Filtrar";
        btnFiltrar.Location = new Point(375, 17);
        btnFiltrar.Size = new Size(110, 34);
        Estilo.Botao(btnFiltrar);
        btnFiltrar.Click += (s, e) => Filtrar();

        // Lista de vendas
        Estilo.Grid(gridVendas);
        gridVendas.Location = new Point(20, 65);
        gridVendas.Size = new Size(920, 240);
        Estilo.Coluna(gridVendas, "Numero", "Nº");
        Estilo.Coluna(gridVendas, "Data", "Data e hora", "dd/MM/yyyy HH:mm");
        Estilo.Coluna(gridVendas, "Cliente", "Cliente");
        Estilo.Coluna(gridVendas, "Pagamento", "Pagamento");
        Estilo.Coluna(gridVendas, "QuantidadeItens", "Itens");
        Estilo.Coluna(gridVendas, "Total", "Total", "C2");
        gridVendas.SelectionChanged += (s, e) => MostrarItens();

        // Itens da venda selecionada
        var lblItens = new Label();
        lblItens.Text = "Itens da venda selecionada";
        lblItens.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        lblItens.Location = new Point(20, 315);
        lblItens.Size = new Size(400, 25);

        Estilo.Grid(gridItens);
        gridItens.Location = new Point(20, 345);
        gridItens.Size = new Size(920, 150);
        Estilo.Coluna(gridItens, "Nome", "Produto");
        Estilo.Coluna(gridItens, "Quantidade", "Qtd");
        Estilo.Coluna(gridItens, "PrecoUnitario", "Unitário", "C2");
        Estilo.Coluna(gridItens, "Subtotal", "Subtotal", "C2");

        // Resumo e botão de fechar
        lblResumo.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        lblResumo.ForeColor = Estilo.Cafe;
        lblResumo.Location = new Point(20, 515);
        lblResumo.Size = new Size(700, 60);

        var btnFechar = new Button();
        btnFechar.Text = "Fechar";
        btnFechar.Location = new Point(830, 530);
        btnFechar.Size = new Size(110, 40);
        Estilo.Botao(btnFechar);
        btnFechar.Click += (s, e) => Close();

        Controls.Add(lblDe);
        Controls.Add(dtpDe);
        Controls.Add(lblAte);
        Controls.Add(dtpAte);
        Controls.Add(btnFiltrar);
        Controls.Add(gridVendas);
        Controls.Add(lblItens);
        Controls.Add(gridItens);
        Controls.Add(lblResumo);
        Controls.Add(btnFechar);
    }

    void Filtrar()
    {
        if (dtpDe.Value.Date > dtpAte.Value.Date)
        {
            MessageBox.Show("A data inicial não pode ser maior que a data final.");
            return;
        }

        List<Venda> todas;

        try
        {
            todas = VendaRepositorio.Listar();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Não foi possível ler as vendas: " + ex.Message);
            return;
        }

        var vendas = todas
            .Where(v => v.Data.Date >= dtpDe.Value.Date && v.Data.Date <= dtpAte.Value.Date)
            .OrderByDescending(v => v.Numero)
            .ToList();

        gridVendas.DataSource = vendas;

        int quantidade = vendas.Count;
        decimal faturamento = vendas.Sum(v => v.Total);
        decimal ticketMedio = quantidade == 0 ? 0 : faturamento / quantidade;

        lblResumo.Text = "Vendas no período: " + quantidade
            + "\nFaturamento: " + faturamento.ToString("C2")
            + "     Ticket médio: " + ticketMedio.ToString("C2");

        MostrarItens();
    }

    void MostrarItens()
    {
        var venda = gridVendas.CurrentRow?.DataBoundItem as Venda;

        if (venda == null)
        {
            gridItens.DataSource = null;
        }
        else
        {
            gridItens.DataSource = venda.Itens;
        }
    }
}
