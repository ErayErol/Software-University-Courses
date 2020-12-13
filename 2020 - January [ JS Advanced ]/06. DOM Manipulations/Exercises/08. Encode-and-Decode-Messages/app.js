function encodeAndDecodeMessages() {
    let buttons = document.getElementsByTagName('button');
    let textArea = document.getElementsByTagName('textArea');

    let decodeText = '';

    buttons[0].addEventListener('click', encode);
    buttons[1].addEventListener('click', decode);

    function decode() {
        textArea[1].textContent = decodeText;
    }

    function encode() {
        let text = textArea[0].value;
        decodeText = text;
        
        let encodeText = '';

        for (let i = 0; i < text.length; i++) {
            let asciNum = text.charCodeAt(i);
            encodeText += String.fromCharCode(asciNum + 1);
        }

        textArea[1].textContent = encodeText;
        textArea[0].value = '';
    }
}