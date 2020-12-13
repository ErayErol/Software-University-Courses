export function withCache(fn, ttl) {
    function resetCache() {
        fn.cache = new Map();
        setTimeout(resetCache, ttl);
    }
    resetCache();
    return function () {
        let key = JSON.stringify(arguments);
        if (!fn.cache.has(key)) {
            fn.cache.set(key, fn(...arguments));
        }
        return fn.cache.get(key);
    };
}
