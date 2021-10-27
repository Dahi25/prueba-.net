using PruebaDahiana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaDahiana.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registro()
        {
            var User = new Usuario();
            return View(User);
        }
    }
}

@model PruebaDahiana.Models.Usuario

@{
    ViewBag.Title = "Garantía";
}
<div style="width: 100%;">
    <h1 class="text-white"> Solicita tus  garantías: </h1>
</div>
@using (Html.BeginForm("", "", FormMethod.Post, new { name = "formulario1", id = "formulario1" }))
{
    @Html.AntiForgeryToken()

    <div class="form-horizontal">

        @Html.ValidationSummary(true, "", new { @class = "text-danger" })
        <div class="d-flex">
            <div>
                <div class=" test">
                    @Html.LabelFor(model => model.Cedula, htmlAttributes: new { @class = "test text-white" })
                    <div class="">
                        @Html.EditorFor(model => model.Cedula, new { htmlAttributes = new { @class = "form-control" } })
                        @Html.ValidationMessageFor(model => model.Cedula, "", new { @class = "text-danger" })
                    </div>
                </div>
                <div class=" test">
                    @Html.TextAreaFor(model => model.Falla, htmlAttributes: new { @class = " test " })

                    
                    <div class="">
                        @*  @Html.EditorFor(model => model.Falla, new { htmlAttributes = new { @class = "form-control" } })*@
                        @Html.ValidationMessageFor(model => model.Falla, "", new { @class = "text-danger" })
                    </div>
                </div>

            </div>
            </div>
            <div class="form-check  text-white">
                <div>
                    @Html.Label("Seleccione el servicio  que necesita garantía:")
                    <div>
                        <div class="d-flex  flex-column ">
                            @Html.Label("Licenciamiento de office 365 ")
                            @Html.CheckBoxFor(m => m.licenciamiento, new { id = "1" })
                        </div>
                        <div class="d-flex  flex-column">
                            @Html.Label("Licenciamiento de Azure ")
                            @Html.CheckBoxFor(m => m.azure, new { id = "2" })
                        </div>
                        <div class="d-flex  flex-column">
                            @Html.Label("Renting tecnológico  ")
                            @Html.CheckBoxFor(m => m.renting, new { id = "3" })
                        </div>

                    </div>

                </div>
            </div>
        </div>
        <div class="">
            <input type="button" value="Enviar" onclick="EnviarFormulario();"  id="envio"   class="btn btn-warning" />
        </div>
}

    <script>
        $(document).ready(function () {
            $('#formulario1').submit(function (e) {
                e.preventDefault()
            }).validate({
                debug: false,
                errorClass: "error nuevo",
                rules: {
                    Cedula: { required: true },
                    Falla: { required: true }
                     messages: {
                        Cedula: {
                            required: "Ingrese porfavor su cedula"
                        },
                        Falla: {
                            required: "Describa las fallas que tiene su servicio"
                         }
                     }
                }
            });
        });
       
    </script>

<script>
    function EnviarFormulario() {
        debugger;

        if ($("#formulario1").valid()) {
            var formulario1 = $("#formulario1").serialize();

            $.ajax({
                type: 'POST',
                url: '@Url.Action("EnviarSolicitud", "Usuarios")',
                data: formulario1,
                success: function (resultado) {
                    swal({
                        type: 'success',
                        title: 'Estimado Usuario',
                        text: 'Su solicitud ha sido enviada',
                        confirmButtonColor: '#7E8A97'
                    }).then(function () {
                        location.reload();
                    });
                }
            });
        }
        }

</script>
                
