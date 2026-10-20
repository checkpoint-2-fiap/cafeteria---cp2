using System.ComponentModel;
using Cafeteria.Dados;
using Cafeteria.Modelos;

namespace Cafeteria.Telas;

public class VendaForm : Form
{
    BindingList<ItemVenda> itens = new BindingList<ItemVenda>();

    DataGridView gridCardapio = new DataGridView();
    DataGridView gridPedido = new DataGridView();
    NumericUpDown numQuantidade = new NumericUpDown();
    TextBox txtCliente = new TextBox();
    ComboBox cmbPagamento = new ComboBox();
    Label lblTotal = new Label();

    public VendaForm()
    {
        Text = "Venda do Café";
        ClientSize = new Size(900, 560);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        BackColor = Estilo.Fundo;
        Font = new Font("Segoe UI", 10);

        CriarLadoEsquerdo();
        CriarLadoDireito();
    }

    // Lado esquerdo: cardápio e botão de adicionar
    void CriarLadoEsquerdo()
    {
        var lblCardapio = new Label();
        lblCardapio.Text = "Cardápio";
        lblCardapio.Font = new Font("Segoe UI", 14, FontStyle.Bold);
        lblCardapio.Location = new Point(20, 15);
        lblCardapio.Size = new Size(300, 30);

        Estilo.Grid(gridCardapio);
        gridCardapio.Location = new Point(20, 55);
        gridCardapio.Size = new Size(400, 330);
        Estilo.Coluna(gridCardapio, "Nome", "Produto");
        Estilo.Coluna(gridCardapio, "Categoria", "Categoria");
        Estilo.Coluna(gridCardapio, "Preco", "Preço", "C2");
        gridCardapio.DataSource = Cardapio.Produtos;
        gridCardapio.CellDoubleClick += (s, e) => AdicionarItem();

        var lblQuantidade = new Label();
        lblQuantidade.Text = "Quantidade:";
        lblQuantidade.Location = new Point(20, 405);
        lblQuantidade.Size = new Size(90, 25);

        numQuantidade.Location = new Point(115, 402);
        numQuantidade.Size = new Size(70, 30);
        numQuantidade.Minimum = 1;
        numQuantidade.Maximum = 50;
        numQuantidade.Value = 1;

        var btnAdicionar = new Button();
        btnAdicionar.Text = "Adicionar ao pedido";
        btnAdicionar.Location = new Point(205, 398);
        btnAdicionar.Size = new Size(215, 36);
        Estilo.Botao(btnAdicionar);
        btnAdicionar.Click += (s, e) => AdicionarItem();

        Controls.Add(lblCardapio);
        Controls.Add(gridCardapio);
        Controls.Add(lblQuantidade);
        Controls.Add(numQuantidade);
        Controls.Add(btnAdicionar);
    }

    // Lado direito: pedido, cliente, pagamento e total
    void CriarLadoDireito()
    {
        var lblPedido = new Label();
        lblPedido.Text = "Pedido";
        lblPedido.Font = new Font("Segoe UI", 14, FontStyle.Bold);
        lblPedido.Location = new Point(450, 15);
        lblPedido.Size = new Size(300, 30);

        Estilo.Grid(gridPedido);
        gridPedido.Location = new Point(450, 55);
        gridPedido.Size = new Size(430, 230);
        Estilo.Coluna(gridPedido, "Nome", "Produto");
        Estilo.Coluna(gridPedido, "Quantidade", "Qtd");
        Estilo.Coluna(gridPedido, "PrecoUnitario", "Unitário", "C2");
        Estilo.Coluna(gridPedido, "Subtotal", "Subtotal", "C2");
        gridPedido.DataSource = itens;

        var btnRemover = new Button();
        btnRemover.Text = "Remover item";
        btnRemover.Location = new Point(450, 297);
        btnRemover.Size = new Size(140, 34);
        Estilo.Botao(btnRemover);
        btnRemover.Click += (s, e) => RemoverItem();

        var lblCliente = new Label();
        lblCliente.Text = "Cliente:";
        lblCliente.Location = new Point(450, 355);
        lblCliente.Size = new Size(90, 25);

        txtCliente.Location = new Point(545, 352);
        txtCliente.Size = new Size(335, 30);

        var lblPagamento = new Label();
        lblPagamento.Text = "Pagamento:";
        lblPagamento.Location = new Point(450, 395);
        lblPagamento.Size = new Size(90, 25);

        cmbPagamento.Location = new Point(545, 392);
        cmbPagamento.Size = new Size(335, 30);
        cmbPagamento.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbPagamento.Items.Add("Dinheiro");
        cmbPagamento.Items.Add("Pix");
        cmbPagamento.Items.Add("Cartão de débito");
        cmbPagamento.Items.Add("Cartão de crédito");

        lblTotal.Text = "Total: R$ 0,00";
        lblTotal.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        lblTotal.ForeColor = Estilo.Cafe;
        lblTotal.Location = new Point(450, 435);
        lblTotal.Size = new Size(430, 35);

        var btnFinalizar = new Button();
        btnFinalizar.Text = "Finalizar venda";
        btnFinalizar.Location = new Point(450, 490);
        btnFinalizar.Size = new Size(210, 42);
        Estilo.Botao(btnFinalizar);
        btnFinalizar.Click += (s, e) => FinalizarVenda();

        var btnCancelar = new Button();
        btnCancelar.Text = "Cancelar";
        btnCancelar.Location = new Point(670, 490);
        btnCancelar.Size = new Size(210, 42);
        Estilo.Botao(btnCancelar);
        btnCancelar.Click += (s, e) => Close();

        Controls.Add(lblPedido);
        Controls.Add(gridPedido);
        Controls.Add(btnRemover);
        Controls.Add(lblCliente);
        Controls.Add(txtCliente);
        Controls.Add(lblPagamento);
        Controls.Add(cmbPagamento);
        Controls.Add(lblTotal);
        Controls.Add(btnFinalizar);
        Controls.Add(btnCancelar);
    }

    void AdicionarItem()
    {
        var produto = gridCardapio.CurrentRow?.DataBoundItem as Produto;

        if (produto == null)
        {
            MessageBox.Show("Selecione um produto do cardápio.");
            return;
        }

        int quantidade = (int)numQuantidade.Value;

        // Se o produto já está no pedido, só soma a quantidade
        var itemExistente = itens.FirstOrDefault(i => i.Nome == produto.Nome);

        if (itemExistente == null)
        {
            var novoItem = new ItemVenda();
            novoItem.Nome = produto.Nome;
            novoItem.Quantidade = quantidade;
            novoItem.PrecoUnitario = produto.Preco;
            itens.Add(novoItem);
        }
        else
        {
            itemExistente.Quantidade += quantidade;
            itens.ResetBindings();
        }

        numQuantidade.Value = 1;
        AtualizarTotal();
    }

    void RemoverItem()
    {
        if (gridPedido.CurrentRow == null)
        {
            MessageBox.Show("Selecione um item do pedido para remover.");
            return;
        }

        itens.RemoveAt(gridPedido.CurrentRow.Index);
        AtualizarTotal();
    }

    void AtualizarTotal()
    {
        decimal total = itens.Sum(i => i.Subtotal);
        lblTotal.Text = "Total: " + total.ToString("C2");
    }

    void FinalizarVenda()
    {
        if (itens.Count == 0)
        {
            MessageBox.Show("Adicione pelo menos um item ao pedido.");
            return;
        }

        if (cmbPagamento.SelectedIndex < 0)
        {
            MessageBox.Show("Escolha a forma de pagamento.");
            return;
        }

        var venda = new Venda();
        venda.Cliente = txtCliente.Text.Trim() == "" ? "Cliente balcão" : txtCliente.Text.Trim();
        venda.Pagamento = cmbPagamento.Text;
        venda.Itens = itens.ToList();

        try
        {
            VendaRepositorio.Salvar(venda);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Não foi possível salvar a venda: " + ex.Message);
            return;
        }

        MessageBox.Show("Venda " + venda.Numero + " registrada!\nTotal: " + venda.Total.ToString("C2"));

        // Limpa a tela para a próxima venda
        itens.Clear();
        txtCliente.Clear();
        cmbPagamento.SelectedIndex = -1;
        AtualizarTotal();
    }
}
