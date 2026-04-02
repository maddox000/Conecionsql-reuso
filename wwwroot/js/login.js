// ==========================================
// ABRIR MODAL SOLO SI EL MODULO NO ESTA ABIERTO
// ==========================================
function abrirModuloConLogin(e, claveModulo, mensaje, destino) {
    e.preventDefault();

    if (localStorage.getItem(claveModulo) === "1") {
        alert(mensaje);
        return;
    }

    const modal = new bootstrap.Modal(document.getElementById('loginTareasModal'));
    modal.show();

    localStorage.setItem("loginDestino", destino);
}

// ==========================================
// RECEPCION - 23
// ==========================================
document.getElementById('btnRecepcion')?.addEventListener('click', function (e) {
    abrirModuloConLogin(
        e,
        "modulo_23_abierto",
        "La recepción ya está abierta.",
        "/Recepcion/CrearRecepcion"
    );
});

// ==========================================
// PROCESOS - 24
// ==========================================
document.getElementById('btnProcesos')?.addEventListener('click', function (e) {
    abrirModuloConLogin(
        e,
        "modulo_24_abierto",
        "El proceso ya está abierto.",
        "/Proceso/CrearProceso"
    );
});

// ==========================================
// ENTREGA - 25
// ==========================================
document.getElementById('btnEntrega')?.addEventListener('click', function (e) {
    abrirModuloConLogin(
        e,
        "modulo_25_abierto",
        "La entrega ya está abierta.",
        "/Entrega/CrearEntrega"
    );
});

// ==========================================
// LAVADO - 134
// ==========================================
document.getElementById('btnLavado')?.addEventListener('click', function (e) {
    abrirModuloConLogin(
        e,
        "modulo_134_abierto",
        "El lavado ya está abierto.",
        "/Lavado/CrearLavado"
    );
});

// ==========================================
// ACONDICIONADO - 135
// ==========================================
document.getElementById('btnAcondicionado')?.addEventListener('click', function (e) {
    abrirModuloConLogin(
        e,
        "modulo_135_abierto",
        "El acondicionado ya está abierto.",
        "/Acondicionado/CrearAcondicionado"
    );
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
// LIMPIAR MODAL AL CERRAR
// ==========================================
document.getElementById('loginTareasModal')?.addEventListener('hidden.bs.modal', function () {
    document.getElementById('loginNombre').value = "";
    document.getElementById('loginUsuarioId').value = "";
    document.getElementById('loginClave').value = "";
    document.getElementById('loginMensaje').innerText = "";
    document.getElementById('listaUsuarios').innerHTML = "";

    usuariosBusqueda = [];
    indiceSeleccionado = -1;
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
// NO DEJAR SALIR DE NOMBRE SIN ELEGIR USUARIO
// ==========================================
document.getElementById('loginNombre')?.addEventListener('blur', function () {
    const id = document.getElementById('loginUsuarioId').value;
    const mensaje = document.getElementById('loginMensaje');

    if (!id && this.value.trim() !== "") {
        mensaje.innerText = "Debe seleccionar un usuario de la lista.";
        this.focus();
    }
});

// ==========================================
// VALIDAR LOGIN
// ==========================================
document.getElementById('btnValidarLogin')?.addEventListener('click', async function () {

    const id = document.getElementById('loginUsuarioId').value;
    const clave = document.getElementById('loginClave').value;
    const mensaje = document.getElementById('loginMensaje');
    const inputNombre = document.getElementById('loginNombre');
    const inputClave = document.getElementById('loginClave');

    mensaje.innerText = "";

    if (!id) {
        mensaje.innerText = "Debe seleccionar un usuario de la lista.";
        inputNombre.focus();
        return;
    }

    if (!clave) {
        mensaje.innerText = "Debe ingresar la clave.";
        inputClave.focus();
        return;
    }

    try {
        const response = await fetch('/APswLog/Validar', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                id: parseInt(id),
                clave: clave
            })
        });

        const data = await response.json();

        if (data.ok) {
            localStorage.setItem("usuarioId", data.id);

            const modal = bootstrap.Modal.getInstance(document.getElementById('loginTareasModal'));
            modal.hide();

            const destino = localStorage.getItem("loginDestino") || "/";

            if (sessionStorage.getItem("primerModulo")) {
                window.open(destino, '_blank');
            } else {
                sessionStorage.setItem("primerModulo", "true");
                window.location.href = destino;
            }

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

    const loginMensaje = document.getElementById('loginMensaje');

    if (!usuariosBusqueda || usuariosBusqueda.length === 0) {
        if (e.key === 'Enter') {
            e.preventDefault();

            if (!document.getElementById('loginUsuarioId').value) {
                loginMensaje.innerText = "Debe seleccionar un usuario de la lista.";
                return;
            }

            document.getElementById('loginClave').focus();
        }
        return;
    }

    if (e.key === 'ArrowDown') {
        e.preventDefault();

        indiceSeleccionado = (indiceSeleccionado + 1) % usuariosBusqueda.length;
        renderizarListaUsuarios();
    }

    if (e.key === 'ArrowUp') {
        e.preventDefault();

        indiceSeleccionado = (indiceSeleccionado - 1 + usuariosBusqueda.length) % usuariosBusqueda.length;
        renderizarListaUsuarios();
    }

    if (e.key === 'Enter') {
        e.preventDefault();

        if (indiceSeleccionado >= 0) {
            const usuario = usuariosBusqueda[indiceSeleccionado];

            document.getElementById('loginUsuarioId').value = usuario.id;
            document.getElementById('loginNombre').value = `${usuario.apellido} ${usuario.nombre}`;
            document.getElementById('listaUsuarios').innerHTML = "";
            usuariosBusqueda = [];
            indiceSeleccionado = -1;

            document.getElementById('loginClave').focus();
        } else {
            loginMensaje.innerText = "Debe seleccionar un usuario de la lista.";
        }
    }
});