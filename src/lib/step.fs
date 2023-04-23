\ lib/step.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230423T1138+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require backward-resolve.fs \ `<resolve`

get-order get-current

compiler-definitions

: step \ Compilation: ( dest -- )
       \ Run-time:    ( R: u -- u' )

  assembler{
  h pop,         \ pop hl
  h a ld,        \ ld a,h
  l or,          \ or l ; z=already zero?
  h decp,        \ dec hl
  h push,        \ push hl
  $0000 nz? ?jp, \ jp nz, dest ; jump to loop
  <resolve       \ resolve _dest_ in the previous `?jp,`
  h pop,         \ pop hl ; discard loop index
  }
  ;

  \ doc{
  \
  \ step
  \   Compilation: ( dest -- )
  \   Run-time:    ( R: u -- u' )

  \ End a ``for``..`step` loop.
  \
  \ Compilation: Compile the run-time semantics described below,
  \ resolving the destination address _dest_, which was left by `for`.
  \
  \ Run-time: If the loop index _u_ is zero, discard it and continue
  \ execution after the loop. Otherwise decrement the loop index and
  \ continue execution at the beginning of the loop.
  \
  \ NOTE: ``step`` was adapted from Garry Lancaster's Z88 CamelForth
  \ (2001). ``step`` is usually called ``next`` in other Forth
  \ systems.
  \
  \ See also: `after`.
  \
  \ }doc

set-current set-order
