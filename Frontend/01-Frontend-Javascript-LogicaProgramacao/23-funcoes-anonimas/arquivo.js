function aloMundo() {
  console.log("Alo mundo!");
}

const aloMundo2 = function () {
  console.log("Alo mundão!");
};

let operacao = aloMundo;

aloMundo();
aloMundo2();
operacao();
operacao = aloMundo2;
operacao();
