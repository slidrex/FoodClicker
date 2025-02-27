package com.foodclicker.game_service.game.shop.services.cosmetics.util;

import com.foodclicker.game_service.food_id.identity_service.exception.UnknownUserException;
import com.foodclicker.game_service.food_id.identity_service.repository.UserRepository;
import com.foodclicker.game_service.food_id.identity_service.service.IdentityService;
import com.foodclicker.game_service.food_id.identity_service.util.IdentityUtil;
import com.foodclicker.game_service.game.shop.services.production.exception.UnknownProductionTemplateId;
import jakarta.transaction.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class CosmeticsUtil {
    @Autowired
    private IdentityUtil identityUtil;
    @Autowired
    private UserRepository userRepository;
    @Transactional
    public void prestigePlayerCosmetics() throws UnknownUserException, UnknownProductionTemplateId {
        var user = identityUtil.getIncomingUser();
        user.getPlayerCosmetics().clear();
        userRepository.save(user);
    }
}
