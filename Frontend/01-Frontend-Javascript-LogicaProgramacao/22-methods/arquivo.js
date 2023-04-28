console.log("Oi mundo, sou eu de novo");

let cliente = {
  nome: "João",
  idade: 25,
  dizerOla() {
    console.log("Olá " + this.nome);
  },
  dirigirCarro() {
    console.log(this.nome + " está dirigindo um carro");
  },
};

cliente.dizerOla();
cliente.dirigirCarro();

const subtrair = function (a, b) {
  return 0;
};

console.log(subtrair(10, 5));
