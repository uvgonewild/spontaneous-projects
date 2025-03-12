import javax.swing.*;
import java.awt.*;

public class MainFrame extends JFrame {
    GamePanel panel;


    public MainFrame(){
        panel = new GamePanel();
        panel.setLocation(0,0);
        panel.setSize(this.getWidth(), this.getHeight());
        panel.setVisible(true);
        panel.setBackground(new Color(5,5,5));
        panel.add(panel.motivate);
        panel.add(panel.bg);
        this.addKeyListener(new KeyChecker(panel));
    }
}
