package com.foodclicker.game_service.game.reset.ascention.util;

import com.foodclicker.game_service.food_id.identity_service.entity.UserEntity;
import com.foodclicker.game_service.food_id.identity_service.exception.UnknownUserException;
import com.foodclicker.game_service.food_id.identity_service.util.IdentityUtil;
import com.foodclicker.game_service.game.reset.ascention.exception.NotEnoughPrestigeLevel;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class AscensionUtil {
    public void hasEnoughPrestigeLevel(UserEntity user, int prestige) throws NotEnoughPrestigeLevel {
        if(user.getPlayerStats().getPrestigeLevel() < prestige) throw new NotEnoughPrestigeLevel();
    }
}
