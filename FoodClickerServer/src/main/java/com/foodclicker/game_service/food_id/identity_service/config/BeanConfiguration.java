package com.foodclicker.game_service.food_id.identity_service.config;

import com.foodclicker.game_service.food_id.identity_service.filter.JWTAuthenticationFilter;
import com.foodclicker.game_service.food_id.identity_service.repository.UserRepository;
import com.foodclicker.game_service.food_id.identity_service.util.DefaultPasswordEncryptor;
import lombok.RequiredArgsConstructor;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.AuthenticationProvider;
import org.springframework.security.authentication.dao.DaoAuthenticationProvider;
import org.springframework.security.config.annotation.authentication.configuration.AuthenticationConfiguration;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.password.PasswordEncoder;

@Configuration
@RequiredArgsConstructor
public class BeanConfiguration {
    private final UserRepository repository;
    @Bean
    public UserDetailsService userDetailsService() {
        return email -> {

            var user = repository.findByEmail(email).orElseThrow(() -> new UsernameNotFoundException("User not found"));

            return user;
        };
    }

    @Bean
    public AuthenticationProvider authenticationProvider() {
        DaoAuthenticationProvider authProvider = new DaoAuthenticationProvider();
        authProvider.setUserDetailsService(userDetailsService());
        authProvider.setPasswordEncoder(passwordEncoder());
        return authProvider;
    }

    @Bean
    public AuthenticationManager authenticationManager(AuthenticationConfiguration config) throws Exception {
        return config.getAuthenticationManager();
    }
    @Bean
    public PasswordEncoder passwordEncoder() {
        return new DefaultPasswordEncryptor();
    }
    @Bean
    public JWTAuthenticationFilter jwtAuthenticationFilterProvider() {
        return new JWTAuthenticationFilter();
    }
}