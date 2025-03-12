import javax.swing.JFrame;

public class Main {
    public static void main(String[] args) {
        MainFrame frame = new MainFrame();

        frame.setSize(600, 700);
        frame.setTitle("TechnoVanza");
        frame.setVisible(true);
        frame.setResizable(false);
        frame.add(frame.panel);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    }
}
