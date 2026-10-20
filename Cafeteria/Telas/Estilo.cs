namespace Cafeteria.Telas;

// Cores e funções que as telas usam para ficarem com o mesmo visual
public static class Estilo
{
    public static Color Cafe = Color.FromArgb(74, 48, 33);
    public static Color Creme = Color.FromArgb(236, 224, 208);
    public static Color Fundo = Color.FromArgb(246, 241, 234);

    public static void Botao(Button botao)
    {
        botao.BackColor = Cafe;
        botao.ForeColor = Color.White;
        botao.FlatStyle = FlatStyle.Flat;
        botao.FlatAppearance.BorderSize = 0;
        botao.Cursor = Cursors.Hand;
    }

    public static void Grid(DataGridView grid)
    {
        grid.AutoGenerateColumns = false;
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.ReadOnly = true;
        grid.RowHeadersVisible = false;
        grid.MultiSelect = false;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        grid.BackgroundColor = Color.White;
        grid.EnableHeadersVisualStyles = false;
        grid.ColumnHeadersDefaultCellStyle.BackColor = Cafe;
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
    }

    public static void Coluna(DataGridView grid, string propriedade, string titulo, string formato = "")
    {
        int posicao = grid.Columns.Add(propriedade, titulo);
        grid.Columns[posicao].DataPropertyName = propriedade;

        if (formato != "")
        {
            grid.Columns[posicao].DefaultCellStyle.Format = formato;
        }
    }
}
