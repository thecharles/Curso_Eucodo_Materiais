var nome = prompt("Qual é o seu nome?");
var idade = parseInt(prompt("Qual é a sua idade?"));

if (nome == "Charles") {
  console.log("Vc é dev");

  if (idade >= 18) {
    console.log("Vc é um dev maior de idade");
  } else {
    console.log("Vc é um dev menor de idade");
  }
} else {
  console.log("Não sei se vc é dev");

  if (idade >= 18) {
    console.log("Vc é um dev maior de idade");
  } else {
    console.log("Vc é um dev menor de idade");

    if (idade >= 18) {
      console.log("Vc é um dev maior de idade");
    } else {
      console.log("Vc é um dev menor de idade");

      if (idade >= 18) {
        console.log("Vc é um dev maior de idade");
      } else {
        console.log("Vc é um dev menor de idade");
      }
    }
  }
}
