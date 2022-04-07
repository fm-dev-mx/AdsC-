using CB_Base.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB
{
    public partial class FrmNuevaMetaProyecto : Ventana
    {
        DateTime FechaPromesa;
        Proceso ProcesoMeta = new Proceso();
        Modulo BuscadorModulos = new Modulo();
        MaterialProyecto BuscadorMaterial = new MaterialProyecto();
        PlanoProyecto BuscadorPlanos = new PlanoProyecto();
        MaterialFabricante BuscadorFabricantes = new MaterialFabricante();
        Decimal IdProyecto = 0;

        public FrmNuevaMetaProyecto(ProyectoProceso proyectoProceso, DateTime fechaPromesa)
        {
            InitializeComponent();
            TxtFechaPromesa.Text = Global.FechaATexto(fechaPromesa, false);
            TxtFechaSolicitud.Text = Global.FechaATexto(DateTime.Now, false);
            IdProyecto = Convert.ToDecimal(proyectoProceso.Fila().Celda("proyecto"));
            FechaPromesa = fechaPromesa;

            ProcesoMeta.CargarDatos(Convert.ToInt32(proyectoProceso.Fila().Celda("proceso")));
            TxtProceso.Text = ProcesoMeta.Fila().Celda("id").ToString().PadLeft(3, '0') + " - " + ProcesoMeta.Fila().Celda("nombre").ToString();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            CrearMeta();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void FrmNuevaMetaProyecto_Load(object sender, EventArgs e)
        {
            CargarTiposEntregables();
            CargarResponsables();
            CargarCoordinadores();
        }

        public void CargarTiposEntregables()
        {
            CmbTipoEntregable.Items.Clear();
            ProcesoSalida.Modelo().TiposEntregables(Convert.ToInt32(ProcesoMeta.Fila().Celda("id"))).ForEach(delegate(Fila f)
            {
                if (f.Celda("tipo_entregable").ToString() != "MATERIAL DE MODULO" && f.Celda("tipo_entregable").ToString() != "MATERIAL DE FABRICANTE" && f.Celda("tipo_entregable").ToString() != "MODULO FABRICADO")
                    CmbTipoEntregable.Items.Add(f.Celda("tipo_entregable"));
            });
        }

        public void CargarResponsables()
        {
            Rol puestoResponsable = new Rol();
            puestoResponsable.CargarDatos(Convert.ToInt32(ProcesoMeta.Fila().Celda("puesto_responsable")));

            CmbResponsable.Items.Clear();

            Usuario.Modelo().SeleccionarUsuariosDeRolConAlmacen(puestoResponsable.Fila().Celda("rol").ToString(), 
                                                       Convert.ToInt32(ProcesoMeta.Fila().Celda("nivel_responsable"))).ForEach(delegate(Fila f)
            {
                CmbResponsable.Items.Add(f.Celda("id") + " - " + f.Celda("nombre") + " " + f.Celda("paterno"));
            });
        }

        public void CargarCoordinadores()
        {
            CmbCoordinador.Items.Clear();
            Usuario.Modelo().SeleccionarRolActivos("COORDINADOR DE OPERACIONES").ForEach(delegate(Fila f)
            {
                CmbCoordinador.Items.Add(f.Celda("id") + " - " + f.Celda("nombre") + " " + f.Celda("paterno"));
            });
        }

        public void CargarEntregables()
        {
            DgvEntregables.Rows.Clear();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            List<Fila> entregables = new List<Fila>();
            string sql = string.Empty;

            switch(CmbTipoEntregable.Text)
            {
                case "MODULO FABRICADO":
                    entregables = BuscadorModulos.ModulosSinMetaDeFabricacion(IdProyecto, FechaPromesa.Date);

                    entregables.ForEach(delegate(Fila f)
                    {
                        DgvEntregables.Rows.Add(f.Celda("id"), false, f.Celda("subensamble").ToString().PadLeft(2, '0') + " " + f.Celda("nombre"));
                    });
                    break;

                case "PARTE FABRICADA":
                    entregables = BuscadorPlanos.PlanosSinMetaDeFabricacion(IdProyecto, FechaPromesa.Date);

                    entregables.ForEach(delegate(Fila f)
                    {
                        DgvEntregables.Rows.Add(f.Celda("id"), false, f.Celda("id").ToString().PadLeft(5, '0') + "  " + f.Celda("nombre_archivo"));
                    });
                    break;

                case "MATERIAL DE REQUISICION":
                    entregables = BuscadorMaterial.RequisicionesSinMetaDeCompras(IdProyecto);

                    entregables.ForEach(delegate(Fila f)
                    {
                        string strEntr = "Req. " + f.Celda("id").ToString().PadLeft(5, '0');
                        strEntr += " | " + f.Celda("fabricante").ToString();
                        strEntr += " | " + f.Celda("numero_parte").ToString();
                        strEntr += " | " + f.Celda("total").ToString();

                        if (f.Celda("tipo_venta").ToString() == "POR PIEZA")
                            strEntr += " pieza(s)";
                        else
                            strEntr += " paquete(s)";

                        DgvEntregables.Rows.Add(f.Celda("id"), false, strEntr);
                    });
                    break;

                case "MATERIAL DE FABRICANTE":
                    entregables = BuscadorMaterial.FabricantesSinMetaDeCompras(IdProyecto);

                    entregables.ForEach(delegate(Fila f)
                    {
                        BuscadorFabricantes.SeleccionarFabricante(f.Celda("fabricante").ToString());

                        if(BuscadorFabricantes.TieneFilas())
                        {
                            DgvEntregables.Rows.Add(BuscadorFabricantes.Fila().Celda("id"), false, BuscadorFabricantes.Fila().Celda("fabricante").ToString());
                        }
                    });
                    break;

                case "MATERIAL DE MODULO":
                    entregables = BuscadorMaterial.ModulosSinMetaDeCompras(IdProyecto);

                    entregables.ForEach(delegate(Fila f)
                    {
                        DgvEntregables.Rows.Add(f.Celda("id"), false, f.Celda("subensamble").ToString().PadLeft(2, '0') + " " + f.Celda("nombre").ToString());
                    });
                    break;

                case "MODULO CONGELADO":
                    entregables = BuscadorModulos.ModulosSinMetaDeCongelacion(IdProyecto);

                    entregables.ForEach(delegate(Fila f)
                    {
                        DgvEntregables.Rows.Add(f.Celda("id"), false, f.Celda("subensamble").ToString().PadLeft(2, '0') + " " + f.Celda("nombre").ToString());
                    });
                    break;
            }
        }

        private void CmbTipoEntregable_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEntregables();
            ValidarDatos();
        }

        public void CrearMeta()
        {
            Fila nuevaMeta = new Fila();
            nuevaMeta.AgregarCelda("proyecto", IdProyecto);           
            nuevaMeta.AgregarCelda("proceso", ProcesoMeta.Fila().Celda("id"));
            nuevaMeta.AgregarCelda("tipo_entregable", CmbTipoEntregable.Text);
            nuevaMeta.AgregarCelda("requisitor", Global.UsuarioActual.Fila().Celda("id"));
            nuevaMeta.AgregarCelda("coordinador", Convert.ToInt32(CmbCoordinador.Text.Split('-')[0]));
            nuevaMeta.AgregarCelda("responsable", Convert.ToInt32(CmbResponsable.Text.Split('-')[0]));
            nuevaMeta.AgregarCelda("fecha_solicitud", DateTime.Now);
            nuevaMeta.AgregarCelda("fecha_promesa", FechaPromesa.Date);
            nuevaMeta = Meta.Modelo().Insertar(nuevaMeta);
            int idNuevaMeta = Convert.ToInt32(nuevaMeta.Celda("id"));

            if(idNuevaMeta > 0)
            {
                foreach (DataGridViewRow fila in DgvEntregables.Rows)
                {
                    bool seleccion = Convert.ToBoolean(fila.Cells["check"].Value);
                    int idEntregable = Convert.ToInt32(fila.Cells["id"].Value);

                    if(seleccion)
                    {
                        Fila nuevoEntregable = new Fila();
                        nuevoEntregable.AgregarCelda("meta", idNuevaMeta);
                        nuevoEntregable.AgregarCelda("tipo_entregable", CmbTipoEntregable.Text);
                        nuevoEntregable.AgregarCelda("id_entregable", idEntregable);
                        MetaEntregable.Modelo().Insertar(nuevoEntregable);

                        EstablecerFechaPromesa(CmbTipoEntregable.Text, idEntregable, idNuevaMeta);

                        if (CmbTipoEntregable.Text == "MATERIAL DE REQUISICION")
                        {
                            Dictionary<string, object> parametros = new Dictionary<string, object>();
                            parametros.Add("@idMaterial", idEntregable);

                            MaterialProyecto mat = new MaterialProyecto();
                            mat.CargarDatos(idEntregable);

                            DateTime fechaLimiteParaOrdenar = (FechaPromesa.Date.AddDays(-Convert.ToInt32(mat.Fila().Celda("tiempo_entrega")))).AddDays(-3);
                            MaterialProyectoKpi materialkpi = new MaterialProyectoKpi();
                            materialkpi.SeleccionarDatos("id_material_proyecto=@idMaterial", parametros);
                            if (materialkpi.TieneFilas())
                            {
                                materialkpi.Fila().ModificarCelda("fecha_meta_colocada", DateTime.Now);
                                materialkpi.Fila().ModificarCelda("fecha_limite_ordenar", fechaLimiteParaOrdenar);
                                materialkpi.GuardarDatos();
                            }
                            else
                            {
                                Fila insertaMaterialKpi = new Fila();
                                insertaMaterialKpi.AgregarCelda("id_material_proyecto", idEntregable);
                                insertaMaterialKpi.AgregarCelda("fecha_meta_colocada", DateTime.Now);
                                materialkpi.Fila().ModificarCelda("fecha_limite_ordenar", fechaLimiteParaOrdenar);
                                materialkpi.Insertar(insertaMaterialKpi);
                            }
                        }
                    }
                }
            }
        }

        public void EstablecerFechaPromesa(string tipoEntregable, int idEntregable, int idMeta)
        {
            switch (tipoEntregable)
            {
                case "MODULO FABRICADO":
                    BuscadorModulos.CargarDatos(idEntregable);

                    if (BuscadorModulos.TieneFilas())
                    {
                        BuscadorModulos.Fila().ModificarCelda("fecha_promesa_fabricacion", FechaPromesa.Date);
                        BuscadorModulos.GuardarDatos();

                        BuscadorPlanos.SeleccionarPlanosDeModulo(IdProyecto, Convert.ToInt32(BuscadorModulos.Fila().Celda("subensamble"))).ForEach(delegate(Fila f)
                        {
                            if(f.Celda("fecha_promesa_fabricacion") == null)
                                f.ModificarCelda("fecha_promesa_fabricacion", FechaPromesa.Date);
                        });
                        BuscadorPlanos.GuardarDatos();
                    }
                    break;

                case "PARTE FABRICADA":
                    BuscadorPlanos.CargarDatos(idEntregable).ForEach(delegate(Fila f)
                    {
                        f.ModificarCelda("fecha_promesa_fabricacion", FechaPromesa.Date);
                    });
                    BuscadorPlanos.GuardarDatos();
                    break;

                case "MATERIAL DE REQUISICION":
                    BuscadorMaterial.CargarDatos(idEntregable).ForEach(delegate(Fila f)
                    {
                        f.ModificarCelda("meta", idMeta);
                        f.ModificarCelda("fecha_promesa_compras", FechaPromesa.Date);
                        f.ModificarCelda("estatus_compra", "EN REVISION FINANCIERA");
                        f.ModificarCelda("estatus_autorizacion", "AUTORIZADO");
                        f.ModificarCelda("fecha_autorizacion", DateTime.Now);
                        Meta metaReq = new Meta();
                        metaReq.CargarDatos(idMeta);
                        if(metaReq.TieneFilas())
                        {
                            metaReq.Fila().ModificarCelda("fecha_autorizacion", DateTime.Now);
                            metaReq.Fila().ModificarCelda("estatus_autorizacion", "AUTORIZADO");
                            metaReq.Fila().ModificarCelda("comentarios_autorizacion", "AUTORIZADO POR SISTEMA");
                            metaReq.GuardarDatos();
                        }
                    });
                    BuscadorMaterial.GuardarDatos();
                    break;

                case "MATERIAL DE FABRICANTE":
                    BuscadorFabricantes.CargarDatos(idEntregable);

                    if(BuscadorFabricantes.TieneFilas())
                    {
                        BuscadorMaterial
                            .SeleccionarMaterialDefinidoAutorizadoDeFabricante(IdProyecto, BuscadorFabricantes.Fila().Celda("fabricante").ToString());

                        BuscadorMaterial.Filas().ForEach(delegate(Fila f)
                        {
                            if (f.Celda("fecha_promesa_compras") == null)
                            {
                                f.ModificarCelda("meta", idMeta); 
                                f.ModificarCelda("fecha_promesa_compras", FechaPromesa.Date);
                                f.ModificarCelda("estatus_compra", "EN REVISION FINANCIERA");
                                f.ModificarCelda("estatus_autorizacion", "AUTORIZADO");
                                f.ModificarCelda("fecha_autorizacion", DateTime.Now);
                            }
                        });
                        BuscadorMaterial.GuardarDatos();
                    }
                    break;

                case "MATERIAL DE MODULO":
                    BuscadorModulos.CargarDatos(idEntregable);

                    if (BuscadorModulos.TieneFilas())
                    {
                        BuscadorModulos.Fila().ModificarCelda("fecha_promesa_compras", FechaPromesa.Date);
                        BuscadorModulos.GuardarDatos();

                        BuscadorMaterial.SeleccionarMaterialDefinidoAutorizadoDeModulo(IdProyecto, Convert.ToInt32(BuscadorModulos.Fila().Celda("subensamble")));
                            
                        BuscadorMaterial.Filas().ForEach(delegate(Fila f)
                        {
                            if (f.Celda("fecha_promesa_compras") == null)
                            {
                                f.ModificarCelda("meta", idMeta); 
                                f.ModificarCelda("fecha_promesa_compras", FechaPromesa.Date);
                                f.ModificarCelda("estatus_compra", "EN REVISION FINANCIERA");
                                f.ModificarCelda("estatus_autorizacion", "AUTORIZADO");
                                f.ModificarCelda("fecha_autorizacion", DateTime.Now);
                            }
                        });
                        BuscadorMaterial.GuardarDatos();
                    }
                    break;

                case "MODULO CONGELADO":
                    BuscadorModulos.CargarDatos(idEntregable);

                    if (BuscadorModulos.TieneFilas())
                    {
                        BuscadorModulos.Fila().ModificarCelda("fecha_promesa_congelacion", FechaPromesa.Date);
                        BuscadorModulos.GuardarDatos();
                    }
                    break;
            }
        }

        public void ValidarDatos()
        {
            BtnRegistrar.Enabled = CmbTipoEntregable.Text != string.Empty && CmbResponsable.Text != string.Empty && CmbCoordinador.Text != string.Empty && EntregablesSeleccionados();
        }

        public bool EntregablesSeleccionados()
        {
            foreach(DataGridViewRow fila in DgvEntregables.Rows)
            {
                bool seleccion = Convert.ToBoolean(fila.Cells["check"].EditedFormattedValue);

                if (seleccion)
                    return true;
            }
            return false;
        }

        private void CmbResponsable_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarDatos();
        }

        private void CmbCoordinador_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarDatos();
        }

        private void DgvEntregables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 1)
                ValidarDatos();
        }
    }
}
