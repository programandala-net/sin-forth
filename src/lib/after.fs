\ lib/after.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

require ahead.fs \ `ahead`
require begin.fs \ `begin`

get-order get-current

compiler-definitions

: after \ Compilation: ( C: dest1 -- orig dest2 )
        \ Run-time:    ( -- )
  drop compiler{ ahead begin } swap ;

  \ doc{
  \
  \  after
  \    Compilation: ( C: dest1 -- orig dest2 )
  \    Run-time:    ( -- )

  \
  \ Compilation: Discard _dest1_ left by `for`. Execute `ahead` to
  \ compile an unconditional `branch`, leaving the address _orig_ of
  \ its unresolved destination, to be resolved by `then`. Execute
  \ `begin` leaving its destination address _dest2_, to be resolved by
  \ `step`.
  \
  \ Run-time: The first time `after` is found in the `do`..`step`
  \ loop, continue the execution at `then`.
  \
  \ Usage example:

  \ ----
  \ 3 for after r@ . then step
  \   \ Display "2 1 0".
  \
  \ 3 for r@ . step
  \   \ Display "3 2 1 0".
  \ ----

  \ NOTE: ``after`` is borrowed from Bill Muench's eForth
  \ (1990..1997), where it's called ``aft``.
  \
  \ }doc

set-current set-order
