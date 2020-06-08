package eu.floringrigoriu.algos;

import junit.framework.Test;
import junit.framework.TestCase;
import junit.framework.TestSuite;

public class p7Test extends TestCase {

    p7.Solution sut = new p7.Solution();
    
    /**
     * Create the test case
     *
     * @param testName name of the test case
     */
    public p7Test( String testName )
    {
        super( testName );
    }

    /**
     * @return the suite of tests being tested
     */
    public static Test suite()
    {
        return new TestSuite(p7Test.class );
    }

    public void testExistingSolution()
    {
        // act
        int r = sut.change(5, new int[] {1,2,5});

        // assert
        assertEquals(4,r);
    }

    public void testNotExistingSolution()
    {
        // act
        int r = sut.change(3, new int[] {2});

        // assert
        assertEquals(0,r);
    }
}