\ lib/again.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230426T1319+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require branch.fs \ `branch`

synonym again branch

  \ doc{
  \
  \ again
  \   Compilation: ( C: dest -- )
  \   Run-time:    ( -- )

  \
  \ Compilation: Compile an unconditional `branch` to the backward
  \ reference _dest_, usually left by `begin`.
  \
  \ Run-time: Continue execution at the location specified by _dest_.
  \
  \ NOTE: `again` is implemented as a synonym of `branch`.
  \
  \ See also: `until`, `repeat`.
  \
  \ }doc
