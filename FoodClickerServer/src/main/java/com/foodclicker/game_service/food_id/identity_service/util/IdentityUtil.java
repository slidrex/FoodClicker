package com.foodclicker.game_service.food_id.identity_service.util;

import com.foodclicker.game_service.food_id.identity_service.entity.UserEntity;
import com.foodclicker.game_service.food_id.identity_service.exception.UnknownUserException;
import com.foodclicker.game_service.food_id.identity_service.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Service;

@Service
public class IdentityUtil {
    @Autowired
    private UserRepository userRepository;
    public UserEntity getIncomingUser() throws UnknownUserException {
        var user = userRepository.findByEmail(SecurityContextHolder.getContext().getAuthentication().getName()).orElseThrow(() -> new UnknownUserException());
        return user;
    }
}
