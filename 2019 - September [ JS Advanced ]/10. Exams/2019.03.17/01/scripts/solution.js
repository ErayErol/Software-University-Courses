function solve() {
   let name = {
      'js-fundamentals': 'JS-Fundamentals',
      'js-advanced': 'JS-Advanced',
      'js-applications': 'JS-Applications',
      'js-web': 'JS-Web',
      'HTML and CSS': 'HTML and CSS',
   };

   let prices = {
      'js-fundamentals': 170,
      'js-advanced': 180,
      'js-applications': 190,
      'js-web': 490,
   };

   let sum = 0;
   let courses = [];
   let cost = document.querySelector('#myCourses > div.courseFoot > p');
   let myCourses = document.querySelector('#myCourses > div.courseBody > ul');
   let onsite = document.querySelector('#educationForm > input[type=radio]:nth-child(2)');

   let signButton = document.querySelector('#availableCourses > div.courseFoot > button');
   signButton.addEventListener('click', signUp);

   function signUp() {
      checkWhichCourseIsChecked();
      checkToAddHtmlAndCss();
      checkIsOnline();
      addCheckedCoursesToMyCourses();

      cost.textContent = `Cost: ${Math.floor(sum).toFixed(2)} BGN`;

      function checkToAddHtmlAndCss() {
         if (courses.length == 4) {
            courses.push('HTML and CSS');
         }
      }

      function checkIsOnline() {
         if (onsite.checked == false) {
            sum *= 0.94;
         }
      }

      function checkWhichCourseIsChecked() {
         let selectedCourses = [...document.querySelectorAll('[type=checkbox]')]
            .filter(c => c.checked === true)
            .map(c => c.value);

         selectedCourses.forEach(c => courses.push(c));

         if (selectedCourses.includes('js-advanced') && selectedCourses.includes('js-fundamentals')) {
            prices['js-advanced'] *= 0.9;
         }

         let sumSelectedCourses = [...document.querySelectorAll("[type=checkbox]")]
            .filter(c => c.checked === true)
            .map(c => Number(prices[c.value]));

         sumSelectedCourses.forEach(c => sum += c);

         if (selectedCourses.includes('js-advanced') && selectedCourses.includes('js-fundamentals') && selectedCourses.includes('js-applications')) {
            sum *= 0.94;
         }
      }
   }

   function addCheckedCoursesToMyCourses() {
      for (const course of courses) {
         let li = document.createElement('li');
         li.textContent = name[course];
         myCourses.appendChild(li);
      }
   }
}

solve();