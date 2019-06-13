function solve() {
  let firstQuestionElement = document.querySelectorAll("h2")[0];
  let secondQuestionElement = document.querySelectorAll("h2")[1];
  let thirdQuestionElement = document.querySelectorAll("h2")[2];

  let answerText1Right = document.getElementsByClassName("answer-text")[0].textContent;
  let answerText2Wrong = document.getElementsByClassName("answer-text")[1].textContent;
  let answerText3Wrong = document.getElementsByClassName("answer-text")[2].textContent;
  let answerText4Right = document.getElementsByClassName("answer-text")[3].textContent;
  let answerText5Right = document.getElementsByClassName("answer-text")[4].textContent;
  let answerText6Wrong = document.getElementsByClassName("answer-text")[5].textContent;

  Array.from(document.getElementsByTagName("p")).forEach((p) => {
    p.addEventListener("click", clickEvent);
  });

  let point = 0;

  function clickEvent(e) {
    let currentTarget = e.currentTarget;

    if (currentTarget.textContent === answerText1Right || currentTarget.textContent === answerText2Wrong) {
      if (currentTarget.textContent === answerText1Right) {
        point++;
      }

      firstQuestionElement.textContent = secondQuestionElement.textContent;
      document.getElementsByTagName("p")[0].textContent = document.getElementsByTagName("p")[2].textContent;
      document.getElementsByTagName("p")[1].textContent = document.getElementsByTagName("p")[3].textContent;
    }else if (currentTarget.textContent === answerText3Wrong || currentTarget.textContent === answerText4Right) {
      if (currentTarget.textContent === answerText4Right) {
        point++;
      }

      firstQuestionElement.textContent = thirdQuestionElement.textContent;
      document.getElementsByTagName("p")[0].textContent = document.getElementsByTagName("p")[4].textContent;
      document.getElementsByTagName("p")[1].textContent = document.getElementsByTagName("p")[5].textContent;
    }else if (currentTarget.textContent === answerText5Right || currentTarget.textContent === answerText6Wrong) {
      if (currentTarget.textContent === answerText5Right) {
        point++;
        console.log(point);
      }
    }

    if (point) {
      
    }
  }
}
