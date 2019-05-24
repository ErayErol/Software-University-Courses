function growingWord() {
  let paragraph = document.getElementsByTagName('p')[2];

  if (!paragraph.style.fontSize) {
      paragraph.style.fontSize = '1px';
  }

  if (paragraph.style.color === 'red') {
      paragraph.style.color = 'blue';
  } else if (paragraph.style.color === 'blue') {
      paragraph.style.color = 'green';
  } else if (paragraph.style.color === 'green') {
      paragraph.style.color = 'red';
  } else {
      paragraph.style.color = 'blue';
  }

  let currentSize = Number(paragraph.style.fontSize.slice(0, -2));
  paragraph.style.fontSize = `${currentSize * 2}px`;
}