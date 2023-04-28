document
  .getElementById("loginEnviar")
  .addEventListener("click", function (event) {
    var email = document.getElementById("loginEmail").value;
    var senha = document.getElementById("loginSenha").value;

    if (!(email === "bob@gmail.com" && senha === "1023")) {
      alert("Usuário e/ou senha inválidos");
      return;
    }

    autenticarUsuario(email);
  });

function autenticarUsuario(email) {
  document.getElementById("formularioLogin").style.display = "none";
  document.getElementById("autenticadoComSucesso").style.display = "block";
  document.getElementById("autenticadoComsucessoEmail").innerHTML = email;
}

document
  .getElementById("loginEsqueciMinhaSenha")
  .addEventListener("click", function (event) {
    document.getElementById("formularioLogin").style.display = "none";
    document.getElementById("esqueciMinhaSenha").style.display = "block";
  });

document
  .getElementById("esqueciMinhaSenhaEnviar")
  .addEventListener("click", function (event) {
    document.getElementById("formularioLogin").style.display = "block";
    document.getElementById("esqueciMinhaSenha").style.display = "none";
    alert("Um e-mail foi enviado para você com a nova senha");
  });
