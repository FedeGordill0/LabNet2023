let numeroAleatorio_h2 = document.querySelector(".numeroAleatorio");
let numero = document.querySelector(".numero");
let btnJugar = document.getElementById("btnJugar");
let mensajeMayorMenor = document.querySelector(".mayorMenor");
let score = document.querySelector(".score");
let highscore = document.querySelector(".highscore");
let btnReiniciar = document.getElementById("btnReiniciar");
let numeroAleatorio1 = Math.floor(Math.random() * 20) + 1;
let puntajePorDefecto = 20;
let mayor = false;

score.value = puntajePorDefecto;
score.innerHTML = puntajePorDefecto;

const numeroRandom = () => {
  let numeroAleatorio = Math.floor(Math.random() * 20) + 1;
  return numeroAleatorio;
};

numeroAleatorio_h2.value = numeroRandom();

btnJugar.addEventListener("click", (e) => {
  e.preventDefault();

  if (
    numero.value != 0 &&
    numero.value <= 20 &&
    typeof numero.value == "string"
  ) {
    if (numero.value == numeroAleatorio_h2.value) {
      numeroAleatorio_h2.innerHTML = numero.value;
      mensajeMayorMenor.innerText = "¡Adivinaste!";

      if (score.value > highscore.innerHTML) {
        mayor = true;
        highscore.innerHTML = score.value;
      } else {
        mayor = false;
      }
    } else if (numero.value > numeroAleatorio_h2.value) {
      mensajeMayorMenor.innerText = "Muy Alto!";
      score.value = score.value - 1;
      score.innerHTML = score.value;
    } else {
      mensajeMayorMenor.innerText = "Muy Bajo!";
      score.value = score.value - 1;
      score.innerHTML = score.value;
    }
  } else {
    Swal.fire({
      position: "top-center",
      icon: "error",
      title: "No se pueden ingresar cadenas o valores incorrectos",
      showConfirmButton: false,
      timer: 1500,
    });
  }

  if (score.value === 0) {
    reiniciar();
  }
});

const reiniciar = () => {
  Swal.fire({
    position: "top-end",
    title: "Reiniciando partida...",
    showConfirmButton: false,
    timer: 1000,
  });

  score.value = puntajePorDefecto;
  score.innerHTML = puntajePorDefecto;
  numeroAleatorio_h2.innerHTML = "?";
  numeroAleatorio_h2.value = numeroRandom();
  numero.value = "";
  mensajeMayorMenor.innerHTML = "";
};

btnReiniciar.addEventListener("click", (e) => {
  e.preventDefault();
  reiniciar();
});
