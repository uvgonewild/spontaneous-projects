import java.awt.Color;
import java.awt.Graphics2D;
import java.awt.Rectangle;

public class Player {
    int x, y;
    int width, height;
    int xSpeed, ySpeed;

    boolean keyUP, keyDOWN, keyLEFT, keyRIGHT;
    Rectangle hitBox;

    GamePanel panel;

    public Player(int x, int y, GamePanel panel){
        this.x = x;
        this.y = y;
        this.panel = panel;

        width = 25;
        height = 50;
        hitBox = new Rectangle(x, y, width, height);
    }

    public void set(){
        if(!panel.gameOver){
            if(keyLEFT && keyRIGHT || !keyLEFT && !keyRIGHT) x *= 1;
            else if (keyLEFT && !keyRIGHT) x -= 5;
            else if (keyRIGHT && !keyLEFT) x += 5;

            if(keyUP){

                hitBox.y++;
                for(Wall wall:panel.walls){
                    if(wall.hitBox.intersects(hitBox)) ySpeed = -8;
                }
                hitBox.y--;

                ySpeed = -8;
            }

            ySpeed += 1;

            // horizontal collision
            hitBox.x += xSpeed;
            for(Wall wall: panel.walls){
                if(hitBox.intersects(wall.hitBox)){
                    hitBox.x -= xSpeed;
                    while(!wall.hitBox.intersects(hitBox)) hitBox.x += Math.signum(xSpeed);
                    hitBox.x -= Math.signum(xSpeed);
                    xSpeed = 0;
                    x = hitBox.x;
                }
            }

            // vertical collision
            hitBox.y += ySpeed;
            for(Wall wall: panel.walls){
                if(hitBox.intersects(wall.hitBox)){
                    hitBox.y -= ySpeed;
                    while(!wall.hitBox.intersects(hitBox)) hitBox.y += Math.signum(ySpeed);
                    hitBox.y -= Math.signum(ySpeed);
                    ySpeed = 0;
                    y = hitBox.y;
                }
            }

            //Game over
            if(hitBox.y >= 1000){
                panel.gameOver = true;
            }

            x += xSpeed;
            y += ySpeed;

            hitBox.x = x;
            hitBox.y = y;
        }
        else{
            y = 5000;
            panel.motivate.setText("GAME OVER!");
        }
    }

    public void draw(Graphics2D g){
        g.setColor(Color.white);
        g.fillRect(x, y, width, height);
    }
}
