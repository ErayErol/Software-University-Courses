function mySolution() {
    let username = document.getElementsByTagName('input')[0];
    let textarea = document.getElementsByTagName('textarea')[0];
    let [_, pendingQuestion, openQuestion] = Array.from(document.getElementsByTagName('div'));

    let btnSend1 = document.getElementsByTagName('button')[0];
    btnSend1.addEventListener('click', sendFunc);
    function sendFunc(e) {
        if (textarea.value) {
            let divPQ1 = document.createElement('div');
            divPQ1.className = 'pendingQuestion';

            let img = document.createElement('img');
            img.src = './images/user.png';
            img.width = 32;
            img.height = 32;
            divPQ1.appendChild(img);

            let span = document.createElement('span');
            if (!username.value) {
                span.textContent = 'Anonymous';
            } else {
                span.textContent = username.value;
            }
            divPQ1.appendChild(span);

            let p = document.createElement('p');
            p.textContent = textarea.value;
            divPQ1.appendChild(p);

            let divPQBtns = document.createElement('div');
            divPQBtns.className = 'actions';

            let btnArchive = document.createElement('button');
            btnArchive.textContent = 'Archive';
            btnArchive.className = 'archive';
            divPQBtns.appendChild(btnArchive);

            let btnOpen = document.createElement('button');
            btnOpen.textContent = 'Open';
            btnOpen.className = 'open';
            divPQBtns.appendChild(btnOpen);

            divPQ1.appendChild(divPQBtns);
            pendingQuestion.appendChild(divPQ1);

            btnArchive.addEventListener('click', archiveFunc);
            function archiveFunc(e) {
                e.target.parentNode.parentNode.parentNode.removeChild(e.target.parentNode.parentNode);
            }

            btnOpen.addEventListener('click', openFunc);
            function openFunc(e) {
                let divOQ1 = document.createElement('div');
                divOQ1.className = 'openQuestion';
                divOQ1.appendChild(e.target.parentNode.parentNode.children[0]);
                divOQ1.appendChild(e.target.parentNode.parentNode.children[0]);
                divOQ1.appendChild(e.target.parentNode.parentNode.children[0]);

                e.target.parentNode.parentNode.parentNode.removeChild(e.target.parentNode.parentNode);

                let divOQBtn = document.createElement('div');
                divOQBtn.className = 'actions';

                let btnReply = document.createElement('button');
                btnReply.textContent = 'Reply';
                btnReply.className = 'reply';
                divOQBtn.appendChild(btnReply);

                divOQ1.appendChild(divOQBtn);

                let divReply = document.createElement('div');
                divReply.className = 'replySection';

                let input = document.createElement('input');
                input.className = 'replyInput';
                input.type = 'text';
                input.placeholder = 'Reply to this question here...';
                divReply.appendChild(input);

                let btnSend2 = document.createElement('button');
                btnSend2.className = 'replyButton';
                btnSend2.textContent = 'Send';
                divReply.appendChild(btnSend2);

                let ol = document.createElement('ol');
                ol.className = 'reply';
                ol.type = '1';
                divReply.appendChild(ol);
                
                divReply.style.display = 'none';
                divOQ1.appendChild(divReply);
                openQuestion.appendChild(divOQ1);

                btnReply.addEventListener('click', replyFunc);
                function replyFunc(e) {
                    if (btnReply.textContent === 'Reply') {
                        divReply.style.display = 'block';
                        btnReply.textContent = 'Back';

                        btnSend2.addEventListener('click', sendFunc2);
                        function sendFunc2(e) {
                            if (input.value) {
                                let li = document.createElement('li');
                                li.textContent = input.value;
                                ol.appendChild(li);
                            }
                        }
                    } else if (btnReply.textContent === 'Back') {
                        divReply.style.display = 'none';
                        btnReply.textContent = 'Reply';
                    }
                }
            }
        }
    }
}