package com.foodclicker.game_service.game.shop.services.production.repository;

import com.foodclicker.game_service.game.shop.services.production.entity.PlayerProductionEntity;
import jakarta.transaction.Transactional;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.repository.CrudRepository;

public interface PlayerProductionRepository extends JpaRepository<PlayerProductionEntity, Long> {
    @Transactional(Transactional.TxType.REQUIRES_NEW)
    void deleteAllByUserId(Long id);
}
