const carros = ["BMW", "Fiat", "VW", "Renault", "Audi"];
let contador = 0;

// estruturação de repetição: for
console.log("Usando o for");
for (contador = 0; contador < carros.length; contador++) {
  console.log(carros[contador] + " encontra-se na posição " + contador);
}

// estruturação de repetição: while
console.log("Usando o while");
contador = 0;
while (contador < carros.length) {
  console.log(carros[contador] + " encontra-se na posição " + contador);
  contador++;
}
