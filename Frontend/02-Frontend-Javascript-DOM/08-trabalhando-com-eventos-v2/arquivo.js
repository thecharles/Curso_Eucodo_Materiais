const botaoEnviar = document.getElementById("enviar");

console.log(botaoEnviar);

botaoEnviar.addEventListener("click", function () {
  console.log("clicado 2");
});

// document.querySelectorAll(".botaoletra").forEach(function (botao) {
//   botao.addEventListener("click", function () {
//     document.getElementById("letraClicada").innerHTML = botao.dataset.letra;
//   });
// });

var listaBotoes = document.querySelectorAll(".botaoletra");

for (var i = 0; i < listaBotoes.length; i++) {
  listaBotoes[i].addEventListener("click", function () {
    document.getElementById("letraClicada").innerHTML = this.dataset.letra;
  });
}
