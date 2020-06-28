package eu.floringrigoriu.algos;

import java.util.HashMap;
import java.util.Map;

public class Counter<T> {
    final Map<T, Integer> counts = new HashMap<>();

    public Integer increment(T t) {
        return counts.merge(t, 1, Integer::sum);
    }

    public int count(T t) {
        return counts.getOrDefault(t, 0);
    }
}