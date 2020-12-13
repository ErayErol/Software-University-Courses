function growingWord() {
  let p = document.querySelectorAll('p')[2];
  let size = p.style.fontSize.slice(0, -2) * 2;

  switch (p.style.color) {
    case 'red':
      p.style.color = 'blue';
      break;
    case 'green':
      p.style.color = 'red';
      break;
    case 'blue':
      p.style.color = 'green';
      break;
    default:
      p.style.color = 'blue';
      p.style.fontSize = '2px';
      break;
  }

  if (size) {
    p.style.fontSize = `${size}px`;
  }
}