function solve() {
  let point = 0;
  let result = document.getElementById('results');
  let answers = document.getElementsByTagName('p');
  let section = document.getElementsByTagName('section');

  section[0].style.display = 'block';
  document.body.addEventListener('click', (e) => {

    if (section[0].style.display == 'block') {
      if (e.target === answers[0]) {
        point++;
      }

      section[0].style.display = 'none';
      section[1].style.display = 'block';
    } else if (section[1].style.display == 'block') {
      if (e.target === answers[3]) {
        point++;
      }

      section[1].style.display = 'none';
      section[2].style.display = 'block';
    } else if (section[2].style.display == 'block') {
      if (e.target === answers[4]) {
        point++;
      }

      section[2].style.display = 'none';
      
      (point === 3)
        ? result.children[0].children[0].textContent = 'You are recognized as top JavaScript fan!'
        : result.children[0].children[0].textContent = `You have ${point} right answers`;

      result.style.display = 'block';
    }
  });
}