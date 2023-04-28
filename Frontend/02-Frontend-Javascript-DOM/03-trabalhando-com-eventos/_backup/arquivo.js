function checkboxGetItensMarcados(checkboxName) {
  var itensMarcados = [];
  var inputElements = document.getElementsByName(checkboxName);
  for (var i = 0; inputElements[i]; ++i) {
    if (inputElements[i].checked) {
      itensMarcados.push(inputElements[i].value);
    }
  }
  return itensMarcados;
}

function checkboxGetItensMarcados2(checkboxName) {
  var itensMarcados = [];
  var inputElements = document.querySelectorAll(
    `input[name='${checkboxName}']`
  );
  for (var i = 0; inputElements[i]; ++i) {
    if (inputElements[i].checked) {
      itensMarcados.push(inputElements[i].value);
    }
  }
  return itensMarcados;
}

document.getElementById("formulario").addEventListener("submit", function (e) {
  e.preventDefault();

  const nome = document.querySelector("input[name='nome']").value;
  const sobrenome = document.querySelector("input[name='sobrenome']").value;
  const cv = document.querySelector("textarea[name='cv']").value;
  const cidade = document.querySelector("select[name='cidade']").value;

  const orientacaoSexual = document.querySelector(
    "input[name='orientacaoSexual']:checked"
  )?.value;

  const funcao = "log";
  console[funcao]({
    nome,
    sobrenome,
    cv,
    cidade,
    orientacaoSexual: orientacaoSexual ? orientacaoSexual : "Não informado",
    arrPatrimonio: checkboxGetItensMarcados("patrimonio"),
    arrPatrimonio2: checkboxGetItensMarcados2("patrimonio"),
  });
});
