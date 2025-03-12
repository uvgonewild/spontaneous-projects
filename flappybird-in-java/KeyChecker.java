import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;

public class KeyChecker extends KeyAdapter{
    GamePanel panel = new GamePanel();

    public KeyChecker(GamePanel panel){
        this.panel = panel;
    }

    public void keyReleased(KeyEvent e){
        panel.keyReleased(e);
    }

    public void keyPressed(KeyEvent e){
        panel.keyPressed(e);
    }
}
