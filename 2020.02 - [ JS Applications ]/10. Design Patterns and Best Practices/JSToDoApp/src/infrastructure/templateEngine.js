export default class TemplateEngine {
    constructor(){
        this.searchExp = /\{\{?([A-Za-z]+)\}\}/;
        this.loopExp = /\{\{loop ?([A-Za-z]+)\}\}?(.+)\{\{endLoop\}\}/s;
    }

    compile(template){
        var searchExp = this.searchExp;
        var loopExp = this.loopExp;
        
        return function(obj){
            var match;
            var result = template;
            var loop;
            
            while (loop = loopExp.exec(result)) {
                var loopResult = '';
                if (Array.isArray(obj[loop[1]])) {
                    obj[loop[1]].forEach(e => {
                        var tempResult = loop[2];
                        while (match = searchExp.exec(tempResult)) {
                            tempResult = tempResult.replace(match[0], e[match[1]]);
                        }

                        loopResult += tempResult;
                    });
                }

                result = result.replace(loop[0], loopResult);
            }

            while (match = searchExp.exec(result)) {
                result = result.replace(match[0], obj[match[1]]);
            }

            return result;
        };
    }
}