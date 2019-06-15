function solve() {
  function clickEvent() {
    if (this.textContent === correctAnswers[sectionNumber - 1]) {
      playerPoints++;
    }

    if (sectionNumber === sectionElements.length - 2) {
      let h1Element = document.getElementsByTagName('h1')[1];

      if (playerPoints === sectionElements.length - 2) {
        h1Element.textContent = 'You are recognized as top JavaScript fan!';
      } else {
        h1Element.textContent = `You have ${playerPoints} right answers`;
      }
    }

    sectionElements[sectionNumber].style.display = 'none';
    sectionElements[sectionNumber + 1].style.display = 'block';
    sectionNumber++;
  }

  let sectionElements = document.getElementById('quizzie').children;
  let sectionNumber = 1;
  let playerPoints = 0;
  let correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];

  Array.from(document.getElementsByTagName("p")).forEach((p) => {
    p.addEventListener("click", clickEvent);
  });
}