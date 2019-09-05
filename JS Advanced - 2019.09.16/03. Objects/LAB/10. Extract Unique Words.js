function solve(input) {
    let set = new Set();

    for (let line of input) {
        let words = line.toLowerCase().split(/\W+/).filter(w => w != "");
        for (let word of words) {
            set.add(word);
        }
    }

    console.log(Array.from(set.keys()).join(", "));
}

solve(['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Pellentesque quis hendrerit dui.',
    'Quisque fringilla est urna, vitae efficitur urna vestibulum fringilla.',
    'Vestibulum dolor diam, dignissim quis varius non, fermentum non felis.',
    'Vestibulum ultrices ex massa, sit amet faucibus nunc aliquam ut.',
    'Morbi in ipsum varius, pharetra diam vel, mattis arcu.',
    'Integer ac turpis commodo, varius nulla sed, elementum lectus.',
    'Vivamus turpis dui, malesuada ac turpis dapibus, congue egestas metus.']
);

solve(['Interdum et malesuada fames ac ante ipsum primis in faucibus.',
    'Vestibulum volutpat lacinia blandit.',
    'Pellentesque dignissim odio in hendrerit lacinia.',
    'Vivamus placerat porttitor purus nec hendrerit.',
    'Aliquam erat volutpat. Donec ac augue ligula.',
    'Praesent venenatis sapien vitae libero ornare, nec pulvinar velit finibus.',
    'Proin dui neque, rutrum vel dolor ut, placerat blandit sapien.',
    'Pellentesque at est arcu.',
    'Nullam eget orci laoreet, feugiat nisi vitae, egestas libero.',
    'Pellentesque pulvinar aliquet felis.',
    'Interdum et malesuada fames ac ante ipsum primis in faucibus.',
    'Etiam sit amet nisl ex.',
    'Sed lacinia pretium metus quis fermentum.',
    'Praesent a ante suscipit, efficitur risus cursus, scelerisque risus.']
);