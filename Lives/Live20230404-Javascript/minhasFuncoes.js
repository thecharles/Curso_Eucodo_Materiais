/*

Charles aqui
nao tente entender isso 
foi copiado da internet como exemplo.

*/

function validarCPF(cpf) {
  // Remove caracteres que não sejam dígitos
  cpf = cpf.replace(/\D/g, "");

  // Verifica se o CPF tem 11 dígitos
  if (cpf.length !== 11) {
    return false;
  }

  // Verifica se todos os dígitos são iguais
  if (/^(\d)\1+$/.test(cpf)) {
    return false;
  }

  // Verifica os dois últimos dígitos (dígitos verificadores)
  const cpfSemDigitosVerificadores = cpf.slice(0, 9);
  const primeiroDigitoVerificador = calcularDigitoVerificador(
    cpfSemDigitosVerificadores
  );
  const segundoDigitoVerificador = calcularDigitoVerificador(
    cpfSemDigitosVerificadores + primeiroDigitoVerificador
  );

  return cpf.endsWith(primeiroDigitoVerificador + segundoDigitoVerificador);
}

function calcularDigitoVerificador(cpfSemDigitosVerificadores) {
  let somatorio = 0;
  for (let i = 0; i < cpfSemDigitosVerificadores.length; i++) {
    somatorio += parseInt(cpfSemDigitosVerificadores[i]) * (10 - i);
  }
  const resto = somatorio % 11;
  return resto < 2 ? "0" : (11 - resto).toString();
}

function validarCNPJ(cnpj) {
  // Remove caracteres que não sejam dígitos
  cnpj = cnpj.replace(/\D/g, "");

  // Verifica se o CNPJ tem 14 dígitos
  if (cnpj.length !== 14) {
    return false;
  }

  // Verifica se todos os dígitos são iguais
  if (/^(\d)\1+$/.test(cnpj)) {
    return false;
  }

  // Verifica os dois últimos dígitos (dígitos verificadores)
  const cnpjSemDigitosVerificadores = cnpj.slice(0, 12);
  const primeiroDigitoVerificador = calcularDigitoVerificador(
    cnpjSemDigitosVerificadores,
    5
  );
  const segundoDigitoVerificador = calcularDigitoVerificador(
    cnpjSemDigitosVerificadores + primeiroDigitoVerificador,
    6
  );

  return cnpj.endsWith(primeiroDigitoVerificador + segundoDigitoVerificador);
}

// function calcularDigitoVerificador(cnpjSemDigitosVerificadores, peso) {
//   let somatorio = 0;
//   for (let i = 0; i < cnpjSemDigitosVerificadores.length; i++) {
//     somatorio += parseInt(cnpjSemDigitosVerificadores[i]) * peso;
//     peso--;
//     if (peso < 2) {
//       peso = 9;
//     }
//   }
//   const resto = somatorio % 11;
//   return resto < 2 ? "0" : (11 - resto).toString();
// }
