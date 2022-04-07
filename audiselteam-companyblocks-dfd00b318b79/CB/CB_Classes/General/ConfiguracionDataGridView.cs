using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace CB_Base.Classes
{
    class ConfiguracionDataGridView
    {
        public int FilaSeleccionada = 0;
        public int ColumnaSeleccionada = 0;
        public int PosicionScrollFila = 0;
        public int PosicionScrollColumna = 0;
        public DataGridViewColumn ColumnaSorteada;
        public SortOrder OrdenSorteo = 0;


        static public ConfiguracionDataGridView Guardar(DataGridView dgv)
        {
            ConfiguracionDataGridView cfg = new ConfiguracionDataGridView();

            cfg.ColumnaSorteada = dgv.SortedColumn;
            cfg.OrdenSorteo = dgv.SortOrder;

            if (dgv.SelectedRows.Count > 0)
                cfg.FilaSeleccionada = dgv.SelectedRows[0].Index;

            if (dgv.SelectedColumns.Count > 0)
                cfg.ColumnaSeleccionada = dgv.SelectedColumns[0].Index;

            cfg.PosicionScrollFila = dgv.FirstDisplayedScrollingRowIndex;
            cfg.PosicionScrollColumna = dgv.FirstDisplayedScrollingColumnIndex;

            return cfg;
        }

        static public DataGridView EsconderColumnasVacias(DataGridView grdView)
        {
            foreach (DataGridViewColumn columna in grdView.Columns)
            {
                bool columnaVacia = true;

                foreach (DataGridViewRow row in grdView.Rows)
                {
                    //verificamos si contiene algo la celda
                    object valorCelda = row.Cells[columna.Index].Value;

                    if (valorCelda != null)
                    {
                        if(valorCelda.ToString() != string.Empty)
                        {
                            //si contiene algo nos salimos, significa que si la mostramos
                            columnaVacia = false;
                            break;
                        }
                    }
                }
                //si no contiene nada ocultamos la columna
                if (columnaVacia)
                    grdView.Columns[columna.Index].Visible = false;

            }
            return grdView;
        }

        static public void Recuperar(ConfiguracionDataGridView cfg, DataGridView dgv)
        {
            try
            {   
                // recuperar columna sorteada
                switch (cfg.OrdenSorteo)
                {
                    case SortOrder.Ascending:
                        dgv.Sort(cfg.ColumnaSorteada, ListSortDirection.Ascending);
                        break;

                    case SortOrder.Descending:
                        dgv.Sort(cfg.ColumnaSorteada, ListSortDirection.Descending);
                        break;
                }
                // recuperar fila seleccionada
                if (cfg.FilaSeleccionada >= 0 && (cfg.FilaSeleccionada < dgv.Rows.Count))
                {
                    dgv.ClearSelection();
                    dgv.Rows[cfg.FilaSeleccionada].Selected = true;
                }
                if (cfg.ColumnaSeleccionada >= 0 && (cfg.ColumnaSeleccionada < dgv.Columns.Count))
                {
                    dgv.ClearSelection();
                    dgv.Columns[cfg.ColumnaSeleccionada].Selected = true;
                }
                // recuperar posicion del scroll
                dgv.FirstDisplayedScrollingRowIndex = cfg.PosicionScrollFila;
                dgv.FirstDisplayedScrollingColumnIndex = cfg.PosicionScrollColumna;
            }
            catch//(Exception ex)
            {

            }
        }

    }
}
