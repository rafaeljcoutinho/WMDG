public class CardFactory{
    public static Card CreateCard(string type, int id){
        if(type == "Bonus"){
            if(id == 0){
                return new Card(){
                    id = id,
                    type = type,
                    name = "More Time",
                    description = "Increase the time by:",
                    image = "/Assets/Images/Icons/bonus_time.png",
                    modifier =  20f
                };
            } else if(id == 1){
                return new Card(){
                    id = id,
                    type = type,
                    name = "Score Multiplier",
                    description = "Increase the score multiplier by 1",
                    image = "/Assets/Images/Icons/score_multiplier.png",
                    modifier =  1f
                };
            }
        } else if(type == "PowerUp"){
            if (id == 0){
                return new Card(){
                    id = id,
                    type = type,
                    name = "Frozen Grenade",
                    description = "You get a frozen grenade",
                    image = "/Assets/Images/Icons/frozen_grenade.png",
                    modifier =  1f
                };
            } else if(id == 1){
                return new Card(){
                    id = id,
                    type = type,
                    name = "Explosive Grenade",
                    description = "You get an explosive grenade",
                    image = "/Assets/Images/Icons/explosive_grenade.png",
                    modifier =  1f
                };
            }
        } else if(type == "Upgrade"){
            if (id == 0){
                return new Card(){
                    id = id,
                    type = type,
                    name = "Precision",
                    description = "Decrease the recoil of your first weapon by:",
                    image = "/Assets/Images/Icons/precision.png",
                    modifier =  0.1f
                };
            } else if(id == 1){
                return new Card(){
                    id = id,
                    type = type,
                    name = "Reload Speed",
                    description = "Increase the reload speed of your first weapon by:",
                    image = "/Assets/Images/Icons/reload_speed.png",
                    modifier =  0.1f
                };
            }
        }
        return null;
    }
}