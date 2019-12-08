class Computer {
    constructor(ramMemory, cpuGHz, hddMemory) {
        this.ramMemory = +ramMemory;
        this.cpuGHz = +cpuGHz;
        this.hddMemory = +hddMemory;
        this.taskManager = [];
        this.installedPrograms = [];
    }

    installAProgram(name, requiredSpace) {
        if (this.hddMemory < requiredSpace) {
            throw new Error('There is not enough space on the hard drive');
        }

        this.hddMemory -= requiredSpace;

        let newProgram = {
            name,
            requiredSpace
        };
        this.installedPrograms.push(newProgram);

        return newProgram;
    }

    uninstallAProgram(name) {
        let program = this.installedPrograms.find(p => p.name === name);
        if (!program) {
            throw new Error('Control panel is not responding');
        }

        this.hddMemory += program.requiredSpace;
        this.installedPrograms = this.installedPrograms.filter(p => p.name !== name);

        return this.installedPrograms;
    }

    openAProgram(name) {
        let program = this.installedPrograms.find(p => p.name === name);
        if (!program) {
            throw new Error(`The ${name} is not recognized`);
        }
        if (program.open) {
            throw new Error(`The ${name} is already open`);
        }
        program.open = true;

        let totalRam = 0;
        this.installedPrograms
            .map((p) => {
                if (p.open) {
                    totalRam += (p.requiredSpace / this.ramMemory) * 1.5
                }
            });

        let totalCPU = 0;
        this.installedPrograms
            .map((p) => {
                if (p.open) {
                    totalCPU += ((p.requiredSpace / this.cpuGHz) / 500) * 1.5
                }
            });

        if (totalRam >= 100 && totalCPU >= 100) {
            throw new Error(`${program.name} caused out of memory exception`);
        }
        if (totalRam >= 100) {
            throw new Error(`${program.name} caused out of memory exception`);
        }
        if (totalCPU >= 100) {
            throw new Error(`${program.name} caused out of cpu exception`);
        }

        let createNewObj = {
            name,
            ramUsage: (program.requiredSpace / this.ramMemory) * 1.5,
            cpuUsage: ((program.requiredSpace / this.cpuGHz) / 500) * 1.5
        };

        this.taskManager.push(createNewObj);
        return createNewObj;
    }

    taskManagerView() {
        if (this.taskManager.length === 0) {
            throw new Error('All running smooth so far');
        }

        let res = [];
        this.taskManager.map(p => res.push(`Name - ${p.name} | Usage - CPU: ${p.cpuUsage.toFixed(0)}%, RAM: ${p.ramUsage.toFixed(0)}%`));
        return res.join('\n');
    }
}

let computer = new Computer(4096, 7.5, 250000);

computer.installAProgram('Word', 7300);
computer.installAProgram('Excel', 10240);
computer.installAProgram('PowerPoint', 12288);
computer.installAProgram('Solitare', 1500);

computer.openAProgram('Word');
computer.openAProgram('Excel');
computer.openAProgram('PowerPoint');
computer.openAProgram('Solitare');

console.log(computer.taskManagerView());