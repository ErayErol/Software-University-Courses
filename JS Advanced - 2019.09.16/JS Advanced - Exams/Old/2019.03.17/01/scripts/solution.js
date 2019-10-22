function solve() {
   function signUp() {
       let totalPrice = 0;

       if (jsFund.checked && jsAdvanced.checked) {
           jsAdvancedPrice -= jsAdvancedPrice * 0.1;
           totalPrice = jsFundPrice + jsAdvancedPrice;
           courses.push('JS-Fundamentals');
           courses.push('JS-Advanced');

           if (jsApps.checked) {
               totalPrice += jsAppsPrice;
               totalPrice -= totalPrice * 0.06;
               courses.push('JS-Applications');

               if (jsWeb.checked) {
                   totalPrice += jsWebPrice;
                   courses.push('JS-Web');
               }
           }

       } else {
           if (jsFund.checked) {
               totalPrice += jsFundPrice;
               courses.push('JS-Fundamentals');
           }

           if (jsAdvanced.checked) {
               totalPrice += jsAdvancedPrice;
               courses.push('JS-Advanced');
           }

           if (jsApps.checked) {
               totalPrice += jsAppsPrice;
               courses.push('JS-Applications');
           }

           if (jsWeb.checked) {
               totalPrice += jsWebPrice;
               courses.push('JS-Web');
           }
       }

       if (courses.length === 4) {
           courses.push('HTML and CSS');
       }

       if (onlineForm.checked) {
           totalPrice -= totalPrice * 0.06;
       }

       for (const course of courses) {
           const liElement = document.createElement('li');
           liElement.textContent = course;
           myCourses.appendChild(liElement);
       }

       price.textContent = `Cost: ${Math.floor(totalPrice)}.00 BGN`;
   }

   let jsFundPrice = 170;
   let jsAdvancedPrice = 180;
   let jsAppsPrice = 190;
   let jsWebPrice = 490;

   const inputElements = document.getElementsByTagName('input');
   const jsFund = inputElements[0];
   const jsAdvanced = inputElements[1];
   const jsApps = inputElements[2];
   const jsWeb = inputElements[3];
   const onlineForm = inputElements[5];
   const myCourses = document.querySelector('#myCourses > div.courseBody > ul');
   const price = document.querySelector('#myCourses > div.courseFoot > p');

   let courses = [];

   const signButton = document.querySelector('button');
   signButton.addEventListener('click', signUp);
}

solve();