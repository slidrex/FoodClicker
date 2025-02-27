package com.foodclicker.game_service.game.social.player_profile.service;

import com.foodclicker.game_service.food_id.identity_service.exception.UnknownUserException;
import com.foodclicker.game_service.food_id.identity_service.util.IdentityUtil;
import com.foodclicker.game_service.game.social.player_profile.model.PlayerProfileModel;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class PlayerProfileService {
    @Autowired
    private IdentityUtil identityUtil;
    public PlayerProfileModel getIncomingUserProfile() throws UnknownUserException {
        var user = identityUtil.getIncomingUser();
        
        
        return new PlayerProfileModel(user.getId(), user.getEmail(), user.getProfile().getRegistrationDate());
    }
}
