function mySolution() {
    let textarea = document.querySelector('#inputSection textarea');
    let input = document.querySelector('#inputSection input');
    let questionBtn = document.querySelector('#inputSection button');
    let pendingQuestions = document.getElementById('pendingQuestions');
    let openQuestions = document.getElementById('openQuestions');

    questionBtn.addEventListener('click', (e) => {
            let textareaCopy = textarea.value;
            textarea.value = '';
            let name = input.value;
            input.value = '';

            let div1 = document.createElement('div');
            div1.className = 'pendingQuestion';
            let img1 = document.createElement('img');
            img1.setAttribute('src', './images/user.png');
            img1.setAttribute('width', 32);
            img1.setAttribute('height', 32);
            let span1 = document.createElement('span');
            (name !== '')
                ? span1.textContent = name
                : span1.textContent = 'Anonymous';
            let p1 = document.createElement('p');
            p1.textContent = textareaCopy;
            let div2 = document.createElement('div');
            div2.className = 'actions';
            let btn1 = document.createElement('button');
            btn1.className = 'archive';
            btn1.textContent = 'Archive';
            let btn2 = document.createElement('button');
            btn2.className = 'open';
            btn2.textContent = 'Open';
            div2.appendChild(btn1);
            div2.appendChild(btn2);
            div1.appendChild(img1);
            div1.appendChild(span1);
            div1.appendChild(p1);
            div1.appendChild(div2);
            pendingQuestions.appendChild(div1);

            btn1.addEventListener('click', (e) => {
                pendingQuestions.removeChild(div1);
            });

            btn2.addEventListener('click', (e) => {
                pendingQuestions.removeChild(div1);



                let div3 = document.createElement('div');
                div3.className = 'openQuestion';

                let img2 = document.createElement('img');
                img2.setAttribute('src', './images/user.png');
                img2.setAttribute('width', 32);
                img2.setAttribute('height', 32);

                let span2 = document.createElement('span');
                (name !== '')
                    ? span2.textContent = name
                    : span2.textContent = 'Anonymous';

                let p2 = document.createElement('p');
                p2.textContent = textareaCopy;

                let div4 = document.createElement('div');
                div4.className = 'actions';

                let btn3 = document.createElement('button');
                btn3.className = 'reply';
                btn3.textContent = 'Reply';


                let div5 = document.createElement('div');
                div5.className = 'replySection';
                div5.style.display = 'none';

                let input2 = document.createElement('input');
                input2.className = 'replyInput';
                input2.type = 'text';
                input2.placeholder = 'Reply to this question here...';

                let btn4 = document.createElement('button');
                btn4.className = 'replyButton';
                btn4.textContent = 'Send';

                let ol = document.createElement('ol');
                ol.className = 'reply';
                ol.type = '1';

                div4.appendChild(btn3);

                div5.appendChild(input2);
                div5.appendChild(btn4);
                div5.appendChild(ol);

                div3.appendChild(img2);
                div3.appendChild(span2);
                div3.appendChild(p2);
                div3.appendChild(div4);
                div3.appendChild(div5);
                openQuestions.appendChild(div3);

                btn3.addEventListener('click', (е) => {

                    if (btn3.textContent === 'Reply') {
                        div5.style.display = 'block';
                        btn3.textContent = 'Back';

                        btn4.addEventListener('click', (er) => {
                            if (input2.value) {
                                let li = document.createElement('li');
                                li.textContent = input2.value;
                                ol.appendChild(li);

                                input2.value = '';
                            }
                        });
                    } else {
                        div5.style.display = 'none';
                        btn3.textContent = 'Reply';
                    }
                });
            });
    });
}