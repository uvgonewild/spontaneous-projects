import java.awt.Color;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.event.KeyEvent;
import java.util.ArrayList;
import java.util.Random;
import java.util.Timer;
import java.util.TimerTask;
import javax.swing.ImageIcon;
import javax.swing.JLabel;
import javax.swing.JPanel;

public class GamePanel extends JPanel{
    Player player;
    AutomatedPlayer automatedPlayer;

    Random randomBlock;
    int yPos;
    int xPos;
    int width;

    boolean gameOver = false;
    JLabel motivate = new JLabel();
    ImageIcon img = new ImageIcon("Image Location -> \\bg.jpeg");
    JLabel bg;

    Timer gameTimer;
    Timer runTimer;
    ArrayList<Wall> walls = new ArrayList<>();

    public GamePanel(){
        this.setLayout(new FlowLayout(FlowLayout.CENTER));
        randomBlock = new Random();

        player = new Player(100, 100, this);
        automatedPlayer = new AutomatedPlayer(200, 100, this);

        motivate.setText("YOU CAN DO IT!");
        motivate.setForeground(new Color(225,225,225));
        motivate.setFont(new Font("Arial", Font.BOLD, 50));
        bg = new JLabel("", img, JLabel.CENTER);

        runTimer = new Timer();
        runTimer.schedule(new TimerTask(){
            @Override
            public void run(){
                if(!gameOver){
                    yPos = randomBlock.nextInt(-300, 0);
                    xPos = randomBlock.nextInt(0, 300);
                    width = randomBlock.nextInt(200, 500);
                    makeWalls();
                    System.out.println(gameOver);
                }
                else motivate.setText("GAME OVER!");
            }
        }, 1, 3500);


        gameTimer = new Timer();
        gameTimer.schedule(new TimerTask(){
            @Override
            public void run() {
                player.set();
                automatedPlayer.set();
                for(Wall wall: walls)wall.set();
                repaint();
            }

        }, 0, 17);

    }
    //creates a wall
    public void makeWalls(){
        walls.add(new Wall(xPos, yPos, width, 25));
    }

    public void paint(Graphics g){
        super.paint(g);
        Graphics2D gtd = (Graphics2D) g;

        player.draw(gtd);
        automatedPlayer.draw(gtd);
        for(Wall wall: walls) wall.draw(g);
    }

    public void keyReleased(KeyEvent e){
        // make everything false
        if(e.getKeyChar() == 'w'){player.keyUP = false; automatedPlayer.keyUP = false;}
        if(e.getKeyChar() == 'a'){player.keyLEFT = false;automatedPlayer.keyRIGHT = false;}
        if(e.getKeyChar() == 's'){player.keyDOWN = false;automatedPlayer.keyDOWN= false;}
        if(e.getKeyChar() == 'd'){player.keyRIGHT = false;automatedPlayer.keyLEFT = false;}
    }

    public void keyPressed(KeyEvent e){
        // make all the values true
        if(e.getKeyChar() == 'w'){player.keyUP = true;automatedPlayer.keyUP = true;}
        if(e.getKeyChar() == 'a'){player.keyLEFT = true;automatedPlayer.keyRIGHT = true;}
        if(e.getKeyChar() == 's'){player.keyDOWN = true;automatedPlayer.keyDOWN = true;}
        if(e.getKeyChar() == 'd'){player.keyRIGHT = true;automatedPlayer.keyLEFT = true;}
    }
}
