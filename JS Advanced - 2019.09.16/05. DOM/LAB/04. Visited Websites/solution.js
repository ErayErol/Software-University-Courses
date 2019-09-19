function solve() {
  
  function f(c) {
    document.querySelectorAll('a')[c].addEventListener("click", function(){
      let x = document.querySelectorAll('p')[c].innerHTML.split(' ');
      let y = document.querySelectorAll('p')[c];
      
      x[1]++;
      y.innerHTML = '';
      y.innerHTML = x.join(' ');
    });
  }

  f(0);
  f(1);
  f(2);
  f(3);
  f(4);
  f(5);
}