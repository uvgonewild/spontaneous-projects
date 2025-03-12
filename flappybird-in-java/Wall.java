import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;

public class Wall {
    int x, y;
    int width, height;

    Rectangle hitBox;

    Wall(int x, int y, int width, int height){
        this.x = x;
        this.y = y;

        this.width = width;
        this.height = height;

        hitBox = new Rectangle(x, y, width, height);
    }

    public void set(){
        y += 1;
        hitBox.y = y;
    }

    public void draw(Graphics g){
        g.setColor(Color.white);
        g.fillRect(x, y, width, height);
    }
}
