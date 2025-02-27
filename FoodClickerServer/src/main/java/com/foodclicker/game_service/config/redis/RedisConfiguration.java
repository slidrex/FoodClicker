package com.foodclicker.game_service.config.redis;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.data.redis.connection.jedis.JedisConnectionFactory;
import org.springframework.data.redis.core.RedisTemplate;
import org.springframework.data.redis.serializer.StringRedisSerializer;

@Configuration
public class RedisConfiguration {

    @Value("${spring.redis.host}")
    private String redisHost;

    @Value("${spring.redis.port}")
    private int redisPort;

    @Bean
    public JedisConnectionFactory redisConnectionFactory() {
        JedisConnectionFactory jedisConnectionFactory = new JedisConnectionFactory();

        jedisConnectionFactory.setHostName(redisHost);

        jedisConnectionFactory.setPort(redisPort);
        jedisConnectionFactory.setUsePool(true);
        jedisConnectionFactory.afterPropertiesSet();
        return jedisConnectionFactory;

    }

    @Bean
    public <T> RedisTemplate<String, T> redisTemplate() {
        RedisTemplate<String, T> redisTemplate = new RedisTemplate<String, T>();

        redisTemplate.setConnectionFactory(redisConnectionFactory());
        redisTemplate.setHashValueSerializer(new StringRedisSerializer());
        redisTemplate.setKeySerializer(new StringRedisSerializer());
        redisTemplate.setValueSerializer(new StringRedisSerializer());
        redisTemplate.setHashKeySerializer(new StringRedisSerializer());
        redisTemplate.afterPropertiesSet();

        return redisTemplate;
    }
}
