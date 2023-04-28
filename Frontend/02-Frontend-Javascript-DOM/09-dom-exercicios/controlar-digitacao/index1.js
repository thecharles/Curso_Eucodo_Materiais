document.querySelectorAll(".controlar-digitacao").forEach(function (elemento) {
  elemento.addEventListener("keypress", function (event) {
    var caracteresPermitidos = this.dataset.caracteresPermitidos ?? "a";
    if (caracteresPermitidos.indexOf(event.key) != -1) {
      return true;
    } else {
      event.preventDefault();
    }
  });
});
