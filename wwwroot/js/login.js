// ==========================================
// ABRIR MODAL DESDE RECEPCIONES
// ==========================================
document.getElementById('btnRecepcion')?.addEventListener('click', function (e) {
    e.preventDefault();

    const modal = new bootstrap.Modal(document.getElementById('loginTareasModal'));
    modal.show();

    localStorage.setItem("loginDestino", "/Recepcion/CrearRecepcion");
});

// ==========================================
// ABRIR MODAL DESDE LAVADO
// ==========================================
document.getElementById('btnLavado')?.addEventListener('click', function (e) {
    e.preventDefault();

    const modal = new bootstrap.Modal(document.getElementById('loginTareasModal'));
    modal.show();

    localStorage.setItem("loginDestino", "/Lavado/CrearLavado");
});

// ==========================================
// ABRIR MODAL DESDE ACONDICIONADO
// ==========================================
document.getElementById('btnAcondicionado')?.addEventListener('click', function (e) {
    e.preventDefault();

    const modal = new bootstrap.Modal(document.getElementById('loginTareasModal'));
    modal.show();

    localStorage.setItem("loginDestino", "/Acondicionado/CrearAcondicionado");
});

// ==========================================
// VARIABLES PARA NAVEGACION CON FLECHAS
// ==========================================
let usuariosBusqueda = [];
let indiceSeleccionado = -1;

// ==========================================
// FOCO AL ABRIR MODAL
// ==========================================
document.getElementById('loginTareasModal')?.addEventListener('shown.bs.modal', function () {
    document.getElementById('loginNombre').focus();
});

// ==========================================
// ENTER EN CLAVE = VALIDAR LOGIN
// ==========================================
document.getElementById('loginClave')?.addEventListener('keypress', function (e) {
    if (e.key === 'Enter') {
        e.preventDefault();
        document.getElementById('btnValidarLogin').click();
    }
});

// ==========================================
// VALIDAR LOGIN
// ==========================================
document.getElementById('btnValidarLogin')?.addEventListener('click', async function () {

    const id = document.getElementById('loginUsuarioId').value;
    const clave = document.getElementById('loginClave').value;
    const mensaje = document.getElementById('loginMensaje');

    mensaje.innerText = "";

    if (!id || !clave) {
        mensaje.innerText = "Debe seleccionar usuario y clave.";
        return;
    }

    try {
        const response = await fetch('/APswLog/Validar', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ id: parseInt(id), clave: clave })
        });

        const data = await response.json();

        if (data.ok) {
            localStorage.setItem("usuarioId", data.id);

            const modal = bootstrap.Modal.getInstance(document.getElementById('loginTareasModal'));
            modal.hide();

            const destino = localStorage.getItem("loginDestino") || "/";
            window.location.href = destino;
        } else {
            mensaje.innerText = data.mensaje || "Clave incorrecta.";
            document.getElementById('loginClave').value = "";
            document.getElementById('loginClave').focus();
        }

    } catch {
        mensaje.innerText = "Error de conexión.";
    }
});

// ==========================================
// FUNCION PARA PINTAR LISTA DE USUARIOS
// ==========================================
function renderizarListaUsuarios() {
    const listaUsuarios = document.getElementById('listaUsuarios');
    const loginNombre = document.getElementById('loginNombre');

    listaUsuarios.innerHTML = "";

    usuariosBusqueda.forEach((usuario, index) => {
        const item = document.createElement("button");
        item.type = "button";
        item.className = "list-group-item list-group-item-action";
        item.textContent = `${usuario.apellido} ${usuario.nombre} - ${usuario.cargo ?? ""}`;

        if (index === indiceSeleccionado) {
            item.classList.add("active");
        }

        item.addEventListener("click", function () {
            document.getElementById('loginUsuarioId').value = usuario.id;
            loginNombre.value = `${usuario.apellido} ${usuario.nombre}`;
            listaUsuarios.innerHTML = "";
            usuariosBusqueda = [];
            indiceSeleccionado = -1;
            document.getElementById('loginClave').focus();
        });

        listaUsuarios.appendChild(item);
    });
}

// ==========================================
// BUSCAR USUARIOS (AUTOCOMPLETE)
// ==========================================
document.getElementById('loginNombre')?.addEventListener('input', function () {

    const texto = this.value.trim();
    const listaUsuarios = document.getElementById('listaUsuarios');
    const loginUsuarioId = document.getElementById('loginUsuarioId');
    const loginMensaje = document.getElementById('loginMensaje');

    loginUsuarioId.value = "";
    listaUsuarios.innerHTML = "";
    loginMensaje.innerText = "";

    usuariosBusqueda = [];
    indiceSeleccionado = -1;

    if (texto.length < 2) return;

    fetch(`/APswLog/Buscar?texto=${encodeURIComponent(texto)}`)
        .then(res => res.json())
        .then(data => {
            if (!data || data.length === 0) return;

            usuariosBusqueda = data;
            indiceSeleccionado = -1;
            renderizarListaUsuarios();
        })
        .catch(() => {
            loginMensaje.innerText = "Error al buscar usuarios.";
        });
});

// ==========================================
// NAVEGACION CON FLECHAS EN LA LISTA
// ==========================================
document.getElementById('loginNombre')?.addEventListener('keydown', function (e) {

    const listaUsuarios = document.getElementById('listaUsuarios');

    if (!usuariosBusqueda || usuariosBusqueda.length === 0) {
        if (e.key === 'Enter') {
            e.preventDefault();
            document.getElementById('loginClave').focus();
        }
        return;
    }

    if (e.key === 'ArrowDown') {
        e.preventDefault();

        if (indiceSeleccionado < usuariosBusqueda.length - 1) {
            indiceSeleccionado++;
        } else {
            indiceSeleccionado = 0;
        }

        renderizarListaUsuarios();
    }

    if (e.key === 'ArrowUp') {
        e.preventDefault();

        if (indiceSeleccionado > 0) {
            indiceSeleccionado--;
        } else {
            indiceSeleccionado = usuariosBusqueda.length - 1;
        }

        renderizarListaUsuarios();
    }

    if (e.key === 'Enter') {
        e.preventDefault();

        if (indiceSeleccionado >= 0 && indiceSeleccionado < usuariosBusqueda.length) {
            const usuario = usuariosBusqueda[indiceSeleccionado];

            document.getElementById('loginUsuarioId').value = usuario.id;
            document.getElementById('loginNombre').value = `${usuario.apellido} ${usuario.nombre}`;
            listaUsuarios.innerHTML = "";
            usuariosBusqueda = [];
            indiceSeleccionado = -1;

            document.getElementById('loginClave').focus();
        } else {
            document.getElementById('loginClave').focus();
        }
    }
});

// ==========================================
// ABRIR MODAL DESDE PROCESOS
// ==========================================
document.getElementById('btnProcesos')?.addEventListener('click', function (e) {
    e.preventDefault();

    const modal = new bootstrap.Modal(document.getElementById('loginTareasModal'));
    modal.show();

    localStorage.setItem("loginDestino", "/Proceso/CrearProceso");
});

// ==========================================
// ABRIR MODAL ENTREGA
// ==========================================

document.getElementById('btnEntrega')?.addEventListener('click', function (e) {
    e.preventDefault();

    const modal = new bootstrap.Modal(document.getElementById('loginTareasModal'));
    modal.show();

    localStorage.setItem("loginDestino", "/Entrega/CrearEntrega");
});